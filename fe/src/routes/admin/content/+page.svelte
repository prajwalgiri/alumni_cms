<script lang="ts">
	import { onMount } from 'svelte';
	import { requireNavigationAccess } from '$lib/utils/routeGuards';
	import {
		apiService,
		type Content,
		ContentType,
		ContentStatus
	} from '$lib/api';
	import { 
		Search, 
		Plus, 
		Edit, 
		Trash2, 
		Eye,
		FileText,
		ChevronLeft,
		ChevronRight,
		Filter,
		Calendar,
		User,
		Bell,
		BookOpen,
		CheckCircle,
		Send
	} from 'lucide-svelte';
	
	let contents: Content[] = [];
	let filteredContents: Content[] = [];
	let loading = true;
	let searchTerm = '';
	let selectedType: string = '';
	let selectedStatus: string = '';
	let currentPage = 1;
	let itemsPerPage = 10;
	let showDeleteModal = false;
	let contentToDelete: Content | null = null;
	let error = "";
	
	const contentTypes = [
		{ value: '', label: 'All Types' },
		{ value: ContentType.News.toString(), label: 'News' },
		{ value: ContentType.Notice.toString(), label: 'Notice' },
		{ value: ContentType.Resource.toString(), label: 'Resource' }
	];
	
	const statusOptions = [
		{ value: '', label: 'All Status' },
		{ value: ContentStatus.Draft.toString(), label: 'Draft' },
		{ value: ContentStatus.Published.toString(), label: 'Published' },
		{ value: ContentStatus.Archived.toString(), label: 'Archived' }
	];
	
	onMount(() => {
		if (requireNavigationAccess()) {
			loadContent();
		}
	});
	
	async function loadContent() {
		loading = true;
		error = "";
		try {
			const response = await apiService.getAdminContent();
			if (response.success && response.data) {
				contents = response.data;
				filterContent();
			} else {
				error = response.message || "Failed to load content";
			}
		} catch (err) {
			console.error('Error loading content:', err);
			error = "An error occurred while loading content";
		} finally {
			loading = false;
		}
	}
	
	function filterContent() {
		filteredContents = contents.filter(item => {
			const matchesSearch = !searchTerm || 
				item.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
				item.body.toLowerCase().includes(searchTerm.toLowerCase()) ||
				item.creatorName.toLowerCase().includes(searchTerm.toLowerCase());
			
			const matchesType = selectedType === '' || item.type.toString() === selectedType;
			const matchesStatus = selectedStatus === '' || item.status.toString() === selectedStatus;
			
			return matchesSearch && matchesType && matchesStatus;
		});
		currentPage = 1;
	}
	
	function getPaginatedContent() {
		const start = (currentPage - 1) * itemsPerPage;
		const end = start + itemsPerPage;
		return filteredContents.slice(start, end);
	}
	
	function getTotalPages() {
		return Math.ceil(filteredContents.length / itemsPerPage);
	}
	
	function confirmDelete(item: Content) {
		contentToDelete = item;
		showDeleteModal = true;
	}
	
	async function handleDelete() {
		if (!contentToDelete) return;
		
		try {
			const response = await apiService.deleteContent(contentToDelete.id);
			if (response.success) {
				contents = contents.filter(item => item.id !== contentToDelete!.id);
				filterContent();
			} else {
				alert(response.message || "Failed to delete content");
			}
		} catch (err) {
			console.error('Error deleting content:', err);
			alert("An error occurred while deleting content");
		} finally {
			showDeleteModal = false;
			contentToDelete = null;
		}
	}

	async function handlePublish(item: Content) {
		try {
			const response = await apiService.publishContent(item.id);
			if (response.success && response.data) {
				const index = contents.findIndex(c => c.id === item.id);
				if (index !== -1) {
					contents[index] = response.data;
					filterContent();
				}
			}
		} catch (err) {
			console.error('Error publishing content:', err);
			alert("An error occurred while publishing content");
		}
	}
	
	function formatDate(dateString: string) {
		return new Date(dateString).toLocaleDateString('en-US', {
			year: 'numeric',
			month: 'short',
			day: 'numeric'
		});
	}
	
	function getContentIcon(type: ContentType) {
		switch (type) {
			case ContentType.News: return Newspaper;
			case ContentType.Notice: return Bell;
			case ContentType.Resource: return BookOpen;
			default: return FileText;
		}
	}

	const Newspaper = FileText; // Fallback if Newspaper icon is missing from lucide-svelte version
	
	function getStatusColor(status: ContentStatus) {
		switch (status) {
			case ContentStatus.Published: return 'bg-green-100 text-green-800';
			case ContentStatus.Draft: return 'bg-yellow-100 text-yellow-800';
			case ContentStatus.Archived: return 'bg-gray-100 text-gray-800';
			default: return 'bg-gray-100 text-gray-800';
		}
	}

	function getStatusLabel(status: ContentStatus) {
		switch (status) {
			case ContentStatus.Published: return 'Published';
			case ContentStatus.Draft: return 'Draft';
			case ContentStatus.Archived: return 'Archived';
			default: return 'Unknown';
		}
	}

	function getTypeLabel(type: ContentType) {
		switch (type) {
			case ContentType.News: return 'News';
			case ContentType.Notice: return 'Notice';
			case ContentType.Resource: return 'Resource';
			default: return 'Unknown';
		}
	}
	
	$: {
		searchTerm, selectedType, selectedStatus;
		filterContent();
	}
</script>

<svelte:head>
	<title>Content Management - Admin CMS</title>
</svelte:head>

<!-- Page Header -->
<div class="mb-8">
	<div class="flex flex-col md:flex-row md:items-center justify-between gap-4">
		<div>
			<h1 class="text-3xl font-bold text-gray-900">Content Management</h1>
			<p class="text-gray-600 mt-2">Manage news, announcements, and resources</p>
		</div>
		<a href="/admin/content/new" class="btn-primary flex items-center justify-center">
			<Plus class="h-5 w-5 mr-2" />
			Create Content
		</a>
	</div>
</div>

{#if loading && contents.length === 0}
	<div class="flex flex-col items-center justify-center h-64">
		<div class="animate-spin rounded-full h-12 w-12 border-b-2 border-primary-600"></div>
		<p class="mt-4 text-gray-600">Loading content...</p>
	</div>
{:else if error}
	<div class="bg-red-50 border-l-4 border-red-400 p-4 mb-6">
		<p class="text-red-700">{error}</p>
		<button onclick={loadContent} class="text-red-700 font-bold underline mt-2">Try Again</button>
	</div>
{:else}
	<!-- Filters and Search -->
	<div class="bg-white rounded-xl shadow-sm border border-gray-200 p-6 mb-6">
		<div class="grid grid-cols-1 md:grid-cols-4 gap-4">
			<div class="relative">
				<Search class="absolute left-3 top-1/2 transform -translate-y-1/2 h-5 w-5 text-gray-400" />
				<input
					type="text"
					placeholder="Search content..."
					bind:value={searchTerm}
					class="w-full pl-10 pr-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-primary-500 focus:border-primary-500"
				/>
			</div>
			
			<select bind:value={selectedType} class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-primary-500 focus:border-primary-500">
				{#each contentTypes as type}
					<option value={type.value}>{type.label}</option>
				{/each}
			</select>
			
			<select bind:value={selectedStatus} class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-primary-500 focus:border-primary-500">
				{#each statusOptions as status}
					<option value={status.value}>{status.label}</option>
				{/each}
			</select>
			
			<div class="flex items-center text-sm text-gray-500">
				{filteredContents.length} items found
			</div>
		</div>
	</div>

	<!-- Content Grid -->
	{#if filteredContents.length === 0}
		<div class="bg-white rounded-xl shadow-sm border border-gray-200 p-12 text-center">
			<FileText class="h-12 w-12 text-gray-300 mx-auto mb-4" />
			<h3 class="text-lg font-medium text-gray-900">No content found</h3>
			<p class="text-gray-500">Try adjusting your filters or create new content.</p>
		</div>
	{:else}
		<div class="grid grid-cols-1 lg:grid-cols-2 xl:grid-cols-3 gap-6">
			{#each getPaginatedContent() as item}
				<div class="bg-white rounded-xl shadow-sm border border-gray-200 hover:shadow-md transition-shadow duration-200 flex flex-col">
					<div class="p-6 flex-1">
						<div class="flex items-start justify-between mb-4">
							<div class="flex items-center">
								<div class="w-10 h-10 bg-primary-50 rounded-lg flex items-center justify-center">
									<svelte:component this={getContentIcon(item.type)} class="h-5 w-5 text-primary-600" />
								</div>
								<div class="ml-3">
									<span class="inline-flex px-2 py-0.5 text-xs font-semibold rounded-full bg-gray-100 text-gray-800 uppercase">
										{getTypeLabel(item.type)}
									</span>
								</div>
							</div>
							<span class="inline-flex px-2 py-0.5 text-xs font-semibold rounded-full {getStatusColor(item.status)}">
								{getStatusLabel(item.status)}
							</span>
						</div>

						<h3 class="text-lg font-bold text-gray-900 mb-2 line-clamp-2">
							{item.title}
						</h3>

						<p class="text-sm text-gray-600 mb-4 line-clamp-3 whitespace-pre-line">
							{item.body}
						</p>

						<div class="flex flex-col space-y-2 text-xs text-gray-500 mb-4">
							<div class="flex items-center">
								<User class="h-3.5 w-3.5 mr-1.5" />
								{item.creatorName}
							</div>
							<div class="flex items-center">
								<Calendar class="h-3.5 w-3.5 mr-1.5" />
								Created: {formatDate(item.createdAt)}
							</div>
							{#if item.publishDate}
								<div class="flex items-center text-primary-600">
									<CheckCircle class="h-3.5 w-3.5 mr-1.5" />
									Published: {formatDate(item.publishDate)}
								</div>
							{/if}
						</div>
					</div>

					<div class="px-6 py-4 bg-gray-50 border-t border-gray-200 rounded-b-xl flex items-center justify-between">
						<div class="flex items-center space-x-1">
							<a href="/news/{item.id}" target="_blank" class="p-2 text-gray-500 hover:text-primary-600 hover:bg-white rounded-lg transition-colors" title="View Publicly">
								<Eye class="h-4 w-4" />
							</a>
							<a href="/admin/content/{item.id}/edit" class="p-2 text-gray-500 hover:text-blue-600 hover:bg-white rounded-lg transition-colors" title="Edit">
								<Edit class="h-4 w-4" />
							</a>
							<button onclick={() => confirmDelete(item)} class="p-2 text-gray-500 hover:text-red-600 hover:bg-white rounded-lg transition-colors" title="Delete">
								<Trash2 class="h-4 w-4" />
							</button>
						</div>

						{#if item.status !== ContentStatus.Published}
							<button
								onclick={() => handlePublish(item)}
								class="text-xs font-bold text-primary-600 hover:text-primary-700 flex items-center"
							>
								<Send class="h-3.5 w-3.5 mr-1" />
								PUBLISH NOW
							</button>
						{/if}
					</div>
				</div>
			{/each}
		</div>

		<!-- Pagination -->
		{#if getTotalPages() > 1}
			<div class="flex flex-col md:flex-row items-center justify-between mt-8 gap-4">
				<div class="text-sm text-gray-600">
					Showing {((currentPage - 1) * itemsPerPage) + 1} to {Math.min(currentPage * itemsPerPage, filteredContents.length)} of {filteredContents.length} results
				</div>
				<div class="flex items-center space-x-2">
					<button
						onclick={() => currentPage = Math.max(1, currentPage - 1)}
						disabled={currentPage === 1}
						class="p-2 text-gray-400 hover:text-gray-600 disabled:opacity-30 disabled:cursor-not-allowed bg-white border border-gray-200 rounded-lg shadow-sm"
					>
						<ChevronLeft class="h-5 w-5" />
					</button>

					<div class="flex items-center space-x-1">
						{#each Array.from({ length: getTotalPages() }, (_, i) => i + 1) as page}
							<button
								onclick={() => currentPage = page}
								class="px-3.5 py-1.5 text-sm font-medium rounded-lg transition-colors {currentPage === page ? 'bg-primary-600 text-white shadow-md' : 'text-gray-700 hover:bg-gray-100 bg-white border border-gray-200'}"
							>
								{page}
							</button>
						{/each}
					</div>

					<button 
						onclick={() => currentPage = Math.min(getTotalPages(), currentPage + 1)}
						disabled={currentPage === getTotalPages()}
						class="p-2 text-gray-400 hover:text-gray-600 disabled:opacity-30 disabled:cursor-not-allowed bg-white border border-gray-200 rounded-lg shadow-sm"
					>
						<ChevronRight class="h-5 w-5" />
					</button>
				</div>
			</div>
		{/if}
	{/if}
{/if}

<!-- Delete Confirmation Modal -->
{#if showDeleteModal}
	<div class="fixed inset-0 z-[100] overflow-y-auto">
		<div class="flex items-center justify-center min-h-screen pt-4 px-4 pb-20 text-center sm:block sm:p-0">
			<div class="fixed inset-0 bg-gray-900/50 backdrop-blur-sm transition-opacity"></div>

			<span class="hidden sm:inline-block sm:align-middle sm:h-screen" aria-hidden="true">&#8203;</span>
			
			<div class="inline-block align-bottom bg-white rounded-2xl text-left overflow-hidden shadow-2xl transform transition-all sm:my-8 sm:align-middle sm:max-w-lg sm:w-full">
				<div class="bg-white px-4 pt-5 pb-4 sm:p-8 sm:pb-4">
					<div class="sm:flex sm:items-start">
						<div class="mx-auto flex-shrink-0 flex items-center justify-center h-12 w-12 rounded-full bg-red-100 sm:mx-0 sm:h-12 sm:w-12">
							<Trash2 class="h-6 w-6 text-red-600" />
						</div>
						<div class="mt-3 text-center sm:mt-0 sm:ml-6 sm:text-left">
							<h3 class="text-xl font-bold text-gray-900">Delete Content</h3>
							<div class="mt-3">
								<p class="text-sm text-gray-500 leading-relaxed">
									Are you sure you want to delete <span class="font-bold text-gray-900">"{contentToDelete?.title}"</span>? This action cannot be undone and the content will be removed from the public site.
								</p>
							</div>
						</div>
					</div>
				</div>
				<div class="bg-gray-50 px-4 py-4 sm:px-8 sm:flex sm:flex-row-reverse gap-3">
					<button 
						onclick={handleDelete}
						class="w-full inline-flex justify-center rounded-xl shadow-sm px-6 py-2.5 bg-red-600 text-sm font-bold text-white hover:bg-red-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-red-500 sm:w-auto transition-colors"
					>
						Delete Permanently
					</button>
					<button 
						onclick={() => { showDeleteModal = false; contentToDelete = null; }}
						class="mt-3 w-full inline-flex justify-center rounded-xl border border-gray-300 shadow-sm px-6 py-2.5 bg-white text-sm font-bold text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary-500 sm:mt-0 sm:w-auto transition-colors"
					>
						Cancel
					</button>
				</div>
			</div>
		</div>
	</div>
{/if}

<style>
	.line-clamp-2 {
		display: -webkit-box;
		-webkit-line-clamp: 2;
		-webkit-box-orient: vertical;
		overflow: hidden;
	}
	
	.line-clamp-3 {
		display: -webkit-box;
		-webkit-line-clamp: 3;
		-webkit-box-orient: vertical;
		overflow: hidden;
	}
</style>
