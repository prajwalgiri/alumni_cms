<script lang="ts">
	import { onMount } from 'svelte';
	import { goto } from '$app/navigation';
	import {
		apiService,
		ContentType,
		ContentStatus,
		type CreateContentRequest
	} from '$lib/api';
	import { requireNavigationAccess } from '$lib/utils/routeGuards';
	import { 
		Save, 
		X, 
		FileText, 
		Eye,
		Bell,
		BookOpen
	} from 'lucide-svelte';
	
	const Newspaper = FileText;

	let loading = false;
	let saving = false;
	let error = "";

	let formData: CreateContentRequest = {
		title: '',
		body: '',
		type: ContentType.News,
		status: ContentStatus.Draft,
		publishDate: undefined
	};
	
	const contentTypes = [
		{ value: ContentType.News, label: 'News' },
		{ value: ContentType.Notice, label: 'Notice' },
		{ value: ContentType.Resource, label: 'Resource' }
	];
	
	const statusOptions = [
		{ value: ContentStatus.Draft, label: 'Draft' },
		{ value: ContentStatus.Published, label: 'Published' },
		{ value: ContentStatus.Archived, label: 'Archived' }
	];
	
	onMount(() => {
		if (!requireNavigationAccess()) {
			return;
		}
	});
	
	async function handleSubmit() {
		if (!formData.title || !formData.body) {
			error = "Title and Body are required";
			return;
		}

		saving = true;
		error = "";
		
		try {
			if (formData.status === ContentStatus.Published && !formData.publishDate) {
				formData.publishDate = new Date().toISOString();
			}

			const response = await apiService.createContent(formData);
			
			if (response.success) {
				goto('/admin/content');
			} else {
				error = response.message || "Failed to create content";
			}
		} catch (err) {
			console.error('Error creating content:', err);
			error = "An error occurred while creating content";
		} finally {
			saving = false;
		}
	}
	
	function handleCancel() {
		goto('/admin/content');
	}

	function getIcon(type: ContentType) {
		switch (type) {
			case ContentType.News: return Newspaper;
			case ContentType.Notice: return Bell;
			case ContentType.Resource: return BookOpen;
			default: return FileText;
		}
	}
</script>

<svelte:head>
	<title>Create New Content - Admin CMS</title>
</svelte:head>

<!-- Page Header -->
<div class="mb-8">
	<div class="flex flex-col md:flex-row md:items-center justify-between gap-4">
		<div>
			<h1 class="text-3xl font-bold text-gray-900">Create New Content</h1>
			<p class="text-gray-600 mt-2">Add news, announcements, or resources to the portal</p>
		</div>
		<div class="flex items-center space-x-3">
			<button onclick={handleCancel} class="px-4 py-2 bg-white border border-gray-300 text-gray-700 rounded-lg hover:bg-gray-50 font-medium flex items-center shadow-sm transition-colors">
				<X class="h-5 w-5 mr-2" />
				Cancel
			</button>
			<button onclick={handleSubmit} disabled={saving} class="btn-primary flex items-center shadow-md">
				<Save class="h-5 w-5 mr-2" />
				{saving ? 'Saving...' : 'Save Content'}
			</button>
		</div>
	</div>
</div>

{#if error}
	<div class="bg-red-50 border-l-4 border-red-400 p-4 mb-8 rounded-r-lg shadow-sm">
		<div class="flex">
			<div class="ml-3">
				<p class="text-sm text-red-700 font-medium">{error}</p>
			</div>
		</div>
	</div>
{/if}

<div class="grid grid-cols-1 lg:grid-cols-3 gap-8">
	<!-- Main Form -->
	<div class="lg:col-span-2 space-y-8">
		<div class="bg-white rounded-2xl shadow-sm border border-gray-200 p-8">
			<h2 class="text-lg font-bold text-gray-900 mb-6 flex items-center">
				<FileText class="h-5 w-5 mr-2 text-primary-600" />
				Main Content
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
					<p class="text-xs text-gray-500 mt-2">
						Tip: Use clear paragraphs and simple language for better readability.
					</p>
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
				{#if formData.title || formData.body}
					<div class="max-w-none">
						<div class="flex items-center space-x-3 mb-4">
							<span class="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-primary-100 text-primary-800">
								Preview
							</span>
						</div>
						<h3 class="text-2xl font-extrabold text-gray-900 mb-4">{formData.title || 'Your Title Here'}</h3>
						<div class="text-gray-700 whitespace-pre-line leading-relaxed">
							{formData.body || 'Your content will appear here...'}
						</div>
					</div>
				{:else}
					<div class="flex flex-col items-center justify-center h-full text-gray-400 py-12">
						<Eye class="h-12 w-12 mb-2 opacity-20" />
						<p class="italic">Fill in the fields above to see a preview</p>
					</div>
				{/if}
			</div>
		</div>
	</div>

	<!-- Sidebar Settings -->
	<div class="space-y-8">
		<div class="bg-white rounded-2xl shadow-sm border border-gray-200 p-8">
			<h2 class="text-lg font-bold text-gray-900 mb-6 flex items-center">
				Settings
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
				
				<div>
					<label for="status" class="block text-sm font-bold text-gray-700 mb-2">Publish Status</label>
					<select id="status" bind:value={formData.status} class="w-full px-4 py-2.5 border border-gray-300 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-primary-500 transition-all font-medium">
						{#each statusOptions as status}
							<option value={status.value}>{status.label}</option>
						{/each}
					</select>
				</div>

				{#if formData.status === ContentStatus.Published}
					<div>
						<label for="publishDate" class="block text-sm font-bold text-gray-700 mb-2">Publish Date</label>
						<input
							id="publishDate"
							type="datetime-local"
							bind:value={formData.publishDate}
							class="w-full px-4 py-2.5 border border-gray-300 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-primary-500 transition-all"
						/>
						<p class="text-xs text-gray-500 mt-2">Leave blank to publish immediately</p>
					</div>
				{/if}
			</div>
		</div>

		<div class="bg-primary-50 rounded-2xl p-6 border border-primary-100">
			<h3 class="text-sm font-bold text-primary-800 mb-2 flex items-center">
				<CheckCircle class="h-4 w-4 mr-1.5" />
				Ready to publish?
			</h3>
			<p class="text-xs text-primary-700 mb-4 leading-relaxed">
				Double-check your content and settings. Published content will be immediately visible on the public news page.
			</p>
			<button
				onclick={handleSubmit}
				disabled={saving}
				class="w-full py-3 bg-primary-600 text-white rounded-xl font-bold text-sm shadow-md hover:bg-primary-700 transition-colors disabled:opacity-50"
			>
				{saving ? 'Processing...' : formData.status === ContentStatus.Published ? 'Publish Now' : 'Save as Draft'}
			</button>
		</div>
	</div>
</div>

<style>
	/* Custom focus ring for form elements */
	:global(.btn-primary) {
		@apply bg-primary-600 text-white px-6 py-2.5 rounded-xl font-bold transition-all hover:bg-primary-700 hover:shadow-lg active:scale-95 disabled:opacity-50 disabled:active:scale-100;
	}
</style>

<script context="module">
	import { CheckCircle } from 'lucide-svelte';
</script>
