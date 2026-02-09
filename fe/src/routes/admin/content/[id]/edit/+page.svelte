<script lang="ts">
	import { onMount } from 'svelte';
	import { page } from '$app/stores';
	import { goto } from '$app/navigation';
	import {
		apiService,
		ContentType,
		ContentStatus,
		type UpdateContentRequest,
		type Content
	} from '$lib/api';
	import { requireNavigationAccess } from '$lib/utils/routeGuards';
	import {
		Save,
		X,
		FileText,
		Eye,
		Bell,
		BookOpen,
		CheckCircle,
		Clock,
		ArrowLeft
	} from 'lucide-svelte';

	const Newspaper = FileText;

	const id = $page.params.id;
	let loading = true;
	let saving = false;
	let error = "";

	let originalContent: Content | null = null;
	let formData: UpdateContentRequest = {
		title: '',
		body: '',
		type: ContentType.News
	};

	const contentTypes = [
		{ value: ContentType.News, label: 'News' },
		{ value: ContentType.Notice, label: 'Notice' },
		{ value: ContentType.Resource, label: 'Resource' }
	];

	onMount(async () => {
		if (!requireNavigationAccess()) return;
		await loadContent();
	});

	async function loadContent() {
		loading = true;
		try {
			const response = await apiService.getContentById(id);
			if (response.success && response.data) {
				originalContent = response.data;
				formData = {
					title: originalContent.title,
					body: originalContent.body,
					type: originalContent.type
				};
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

	async function handleSubmit() {
		if (!formData.title || !formData.body) {
			error = "Title and Body are required";
			return;
		}

		saving = true;
		error = "";

		try {
			const response = await apiService.updateContent(id, formData);

			if (response.success) {
				goto('/admin/content');
			} else {
				error = response.message || "Failed to update content";
			}
		} catch (err) {
			console.error('Error updating content:', err);
			error = "An error occurred while updating content";
		} finally {
			saving = false;
		}
	}

	function handleCancel() {
		goto('/admin/content');
	}

	function formatDate(dateString?: string) {
		if (!dateString) return "N/A";
		return new Date(dateString).toLocaleString();
	}

	function getStatusLabel(status: ContentStatus) {
		switch (status) {
			case ContentStatus.Published: return 'Published';
			case ContentStatus.Draft: return 'Draft';
			case ContentStatus.Archived: return 'Archived';
			default: return 'Unknown';
		}
	}

	function getStatusColor(status: ContentStatus) {
		switch (status) {
			case ContentStatus.Published: return 'bg-green-100 text-green-800';
			case ContentStatus.Draft: return 'bg-yellow-100 text-yellow-800';
			case ContentStatus.Archived: return 'bg-gray-100 text-gray-800';
			default: return 'bg-gray-100 text-gray-800';
		}
	}
</script>

<svelte:head>
	<title>Edit Content - Admin CMS</title>
</svelte:head>

<!-- Page Header -->
<div class="mb-8">
	<div class="flex flex-col md:flex-row md:items-center justify-between gap-4">
		<div>
			<a href="/admin/content" class="text-sm text-primary-600 hover:text-primary-700 font-bold flex items-center mb-2">
				<ArrowLeft class="h-4 w-4 mr-1" />
				Back to List
			</a>
			<h1 class="text-3xl font-bold text-gray-900">Edit Content</h1>
			<p class="text-gray-600 mt-2">Modify existing announcement or news item</p>
		</div>
		<div class="flex items-center space-x-3">
			<button onclick={handleCancel} class="px-4 py-2 bg-white border border-gray-300 text-gray-700 rounded-lg hover:bg-gray-50 font-medium flex items-center shadow-sm transition-colors">
				<X class="h-5 w-5 mr-2" />
				Cancel
			</button>
			<button onclick={handleSubmit} disabled={saving || loading} class="btn-primary flex items-center shadow-md">
				<Save class="h-5 w-5 mr-2" />
				{saving ? 'Updating...' : 'Update Content'}
			</button>
		</div>
	</div>
</div>

{#if loading}
	<div class="flex flex-col items-center justify-center h-64 bg-white rounded-2xl border border-gray-100 shadow-sm">
		<div class="animate-spin rounded-full h-12 w-12 border-b-2 border-primary-600"></div>
		<p class="mt-4 text-gray-600">Loading content data...</p>
	</div>
{:else if error}
	<div class="bg-red-50 border-l-4 border-red-400 p-4 mb-8 rounded-r-lg shadow-sm">
		<div class="flex">
			<div class="ml-3">
				<p class="text-sm text-red-700 font-medium">{error}</p>
				<button onclick={loadContent} class="text-xs text-red-700 font-bold underline mt-2">Reload Data</button>
			</div>
		</div>
	</div>
{:else}
	<div class="grid grid-cols-1 lg:grid-cols-3 gap-8">
		<!-- Main Form -->
		<div class="lg:col-span-2 space-y-8">
			<div class="bg-white rounded-2xl shadow-sm border border-gray-200 p-8">
				<h2 class="text-lg font-bold text-gray-900 mb-6 flex items-center">
					<FileText class="h-5 w-5 mr-2 text-primary-600" />
					Edit Information
				</h2>

				<div class="space-y-6">
					<div>
						<label for="title" class="block text-sm font-bold text-gray-700 mb-2">Title</label>
						<input
							id="title"
							type="text"
							bind:value={formData.title}
							class="w-full px-4 py-3 border border-gray-300 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-primary-500 transition-all text-lg font-medium"
							placeholder="Enter an engaging title..."
							required
						/>
					</div>

					<div>
						<label for="body" class="block text-sm font-bold text-gray-700 mb-2">Body Content</label>
						<textarea
							id="body"
							bind:value={formData.body}
							rows="15"
							class="w-full px-4 py-3 border border-gray-300 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-primary-500 transition-all font-mono text-sm leading-relaxed"
							placeholder="Write your update here..."
							required
						></textarea>
					</div>
				</div>
			</div>

			<!-- Preview -->
			<div class="bg-white rounded-2xl shadow-sm border border-gray-200 p-8">
				<h2 class="text-lg font-bold text-gray-900 mb-6 flex items-center">
					<Eye class="h-5 w-5 mr-2 text-primary-600" />
					Live Preview
				</h2>

				<div class="border border-gray-100 rounded-2xl p-8 bg-gray-50 min-h-[200px]">
					<div class="max-w-none">
						<h3 class="text-2xl font-extrabold text-gray-900 mb-4">{formData.title || 'Your Title Here'}</h3>
						<div class="text-gray-700 whitespace-pre-line leading-relaxed">
							{formData.body || 'Your content will appear here...'}
						</div>
					</div>
				</div>
			</div>
		</div>

		<!-- Sidebar Info & Settings -->
		<div class="space-y-8">
			<div class="bg-white rounded-2xl shadow-sm border border-gray-200 p-8">
				<h2 class="text-lg font-bold text-gray-900 mb-6 flex items-center">
					Metadata
				</h2>

				<div class="space-y-6">
					<div>
						<label for="type" class="block text-sm font-bold text-gray-700 mb-2">Content Type</label>
						<select id="type" bind:value={formData.type} class="w-full px-4 py-2.5 border border-gray-300 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-primary-500 transition-all font-medium">
							{#each contentTypes as type}
								<option value={type.value}>{type.label}</option>
							{/each}
						</select>
					</div>

					{#if originalContent}
						<div class="pt-4 border-t border-gray-100 space-y-4">
							<div class="flex justify-between items-center">
								<span class="text-xs text-gray-500 font-bold uppercase tracking-wider">Status</span>
								<span class="inline-flex px-2 py-0.5 text-xs font-bold rounded-full {getStatusColor(originalContent.status)}">
									{getStatusLabel(originalContent.status)}
								</span>
							</div>

							<div class="flex items-start">
								<Clock class="h-4 w-4 text-gray-400 mr-2 mt-0.5" />
								<div>
									<p class="text-xs text-gray-500">Created</p>
									<p class="text-xs font-bold text-gray-900">{formatDate(originalContent.createdAt)}</p>
								</div>
							</div>

							{#if originalContent.publishDate}
								<div class="flex items-start">
									<CheckCircle class="h-4 w-4 text-green-500 mr-2 mt-0.5" />
									<div>
										<p class="text-xs text-gray-500">Published</p>
										<p class="text-xs font-bold text-gray-900">{formatDate(originalContent.publishDate)}</p>
									</div>
								</div>
							{/if}

							<div class="flex items-start">
								<User class="h-4 w-4 text-gray-400 mr-2 mt-0.5" />
								<div>
									<p class="text-xs text-gray-500">Author</p>
									<p class="text-xs font-bold text-gray-900">{originalContent.creatorName}</p>
								</div>
							</div>
						</div>
					{/if}
				</div>
			</div>

			<div class="bg-primary-50 rounded-2xl p-6 border border-primary-100">
				<h3 class="text-sm font-bold text-primary-800 mb-2">Save Changes</h3>
				<p class="text-xs text-primary-700 mb-4 leading-relaxed">
					Updating this content will reflect immediately across the platform.
				</p>
				<button
					onclick={handleSubmit}
					disabled={saving}
					class="w-full py-3 bg-primary-600 text-white rounded-xl font-bold text-sm shadow-md hover:bg-primary-700 transition-colors disabled:opacity-50"
				>
					{saving ? 'Updating...' : 'Save Changes'}
				</button>
			</div>
		</div>
	</div>
{/if}

<style>
	:global(.btn-primary) {
		@apply bg-primary-600 text-white px-6 py-2.5 rounded-xl font-bold transition-all hover:bg-primary-700 hover:shadow-lg active:scale-95 disabled:opacity-50 disabled:active:scale-100;
	}
</style>
