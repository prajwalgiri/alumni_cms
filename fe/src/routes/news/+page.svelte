<script lang="ts">
	import { onMount } from "svelte";
	import { apiService, type Content, ContentType } from "$lib/api";
	import {
		Newspaper,
		Bell,
		Calendar,
		User,
		ArrowRight,
		Search,
		Filter,
	} from "lucide-svelte";

	let contents: Content[] = [];
	let loading = true;
	let error = "";
	let activeType: ContentType | 'all' = 'all';

	onMount(async () => {
		await loadContent();
	});

	async function loadContent() {
		loading = true;
		try {
			const type = activeType === 'all' ? undefined : activeType;
			const response = await apiService.getPublishedContent(type);
			if (response.success && response.data) {
				contents = response.data;
			}
		} catch (err) {
			error = "Failed to load news and updates";
			console.error("Error loading content:", err);
		} finally {
			loading = false;
		}
	}

	function setType(type: ContentType | 'all') {
		activeType = type;
		loadContent();
	}

	function formatDate(dateString?: string) {
		if (!dateString) return "Recently";
		return new Date(dateString).toLocaleDateString("en-US", {
			year: "numeric",
			month: "long",
			day: "numeric",
		});
	}

	function getIcon(type: ContentType) {
		switch (type) {
			case ContentType.News: return Newspaper;
			case ContentType.Notice: return Bell;
			default: return Newspaper;
		}
	}

	function getTypeLabel(type: ContentType) {
		switch (type) {
			case ContentType.News: return "News";
			case ContentType.Notice: return "Notice";
			case ContentType.Resource: return "Resource";
			default: return "Update";
		}
	}

	function getTypeColor(type: ContentType) {
		switch (type) {
			case ContentType.News: return "bg-blue-100 text-blue-800";
			case ContentType.Notice: return "bg-amber-100 text-amber-800";
			case ContentType.Resource: return "bg-emerald-100 text-emerald-800";
			default: return "bg-gray-100 text-gray-800";
		}
	}
</script>

<svelte:head>
	<title>News & Updates - Alumni Network</title>
</svelte:head>

<!-- Hero Section -->
<section class="bg-gradient-to-br from-primary-700 to-primary-900 text-white py-16">
	<div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
		<div class="text-center">
			<h1 class="text-4xl md:text-5xl font-bold mb-4">News & Updates</h1>
			<p class="text-xl text-primary-100 max-w-3xl mx-auto">
				Stay informed about the latest happenings, announcements, and resources from our organization.
			</p>
		</div>
	</div>
</section>

<!-- Filter Section -->
<section class="bg-white border-b border-gray-200 sticky top-0 z-10 shadow-sm">
	<div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
		<div class="flex items-center space-x-4 py-4 overflow-x-auto no-scrollbar">
			<button
				onclick={() => setType('all')}
				class="px-4 py-2 rounded-full text-sm font-medium transition-colors {activeType === 'all' ? 'bg-primary-600 text-white' : 'bg-gray-100 text-gray-700 hover:bg-gray-200'}"
			>
				All Updates
			</button>
			<button
				onclick={() => setType(ContentType.News)}
				class="px-4 py-2 rounded-full text-sm font-medium transition-colors {activeType === ContentType.News ? 'bg-primary-600 text-white' : 'bg-gray-100 text-gray-700 hover:bg-gray-200'}"
			>
				News
			</button>
			<button
				onclick={() => setType(ContentType.Notice)}
				class="px-4 py-2 rounded-full text-sm font-medium transition-colors {activeType === ContentType.Notice ? 'bg-primary-600 text-white' : 'bg-gray-100 text-gray-700 hover:bg-gray-200'}"
			>
				Notices
			</button>
		</div>
	</div>
</section>

<!-- Content Section -->
<section class="py-12 bg-gray-50 min-h-[600px]">
	<div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
		{#if loading}
			<div class="text-center py-20">
				<div class="animate-spin rounded-full h-12 w-12 border-b-2 border-primary-600 mx-auto"></div>
				<p class="mt-4 text-gray-600">Loading updates...</p>
			</div>
		{:else if error}
			<div class="bg-red-50 border-l-4 border-red-400 p-4 mb-8">
				<div class="flex">
					<div class="flex-shrink-0">
						<svg class="h-5 w-5 text-red-400" viewBox="0 0 20 20" fill="currentColor">
							<path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clip-rule="evenodd" />
						</svg>
					</div>
					<div class="ml-3">
						<p class="text-sm text-red-700">{error}</p>
					</div>
				</div>
			</div>
		{:else if contents.length === 0}
			<div class="text-center py-20 bg-white rounded-xl shadow-sm border border-gray-100">
				<div class="w-20 h-20 bg-gray-100 rounded-full flex items-center justify-center mx-auto mb-6">
					<Search class="w-10 h-10 text-gray-400" />
				</div>
				<h3 class="text-xl font-semibold text-gray-900 mb-2">No updates found</h3>
				<p class="text-gray-600">Check back later for new announcements and news items.</p>
			</div>
		{:else}
			<div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
				{#each contents as item}
					<article class="bg-white rounded-xl shadow-sm hover:shadow-md transition-shadow border border-gray-100 overflow-hidden flex flex-col">
						<div class="p-6 flex-1">
							<div class="flex items-center justify-between mb-4">
								<span class="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium {getTypeColor(item.type)}">
									<svelte:component this={getIcon(item.type)} class="w-3 h-3 mr-1" />
									{getTypeLabel(item.type)}
								</span>
								<span class="text-xs text-gray-500 flex items-center">
									<Calendar class="w-3 h-3 mr-1" />
									{formatDate(item.publishDate)}
								</span>
							</div>

							<h2 class="text-xl font-bold text-gray-900 mb-3 line-clamp-2 hover:text-primary-600">
								<a href="/news/{item.id}">{item.title}</a>
							</h2>

							<p class="text-gray-600 mb-4 line-clamp-3 whitespace-pre-line">
								{item.body}
							</p>
						</div>

						<div class="px-6 py-4 bg-gray-50 border-t border-gray-100 flex items-center justify-between">
							<div class="flex items-center text-sm text-gray-500">
								<User class="w-4 h-4 mr-1" />
								<span>{item.creatorName}</span>
							</div>
							<a href="/news/{item.id}" class="text-primary-600 font-semibold text-sm flex items-center hover:translate-x-1 transition-transform">
								Read More <ArrowRight class="w-4 h-4 ml-1" />
							</a>
						</div>
					</article>
				{/each}
			</div>
		{/if}
	</div>
</section>

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
	.no-scrollbar::-webkit-scrollbar {
		display: none;
	}
	.no-scrollbar {
		-ms-overflow-style: none;
		scrollbar-width: none;
	}
</style>
