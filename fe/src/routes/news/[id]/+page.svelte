<script lang="ts">
	import { onMount } from "svelte";
	import { page } from "$app/stores";
	import { apiService, type Content, ContentType } from "$lib/api";
	import {
		Newspaper,
		Bell,
		Calendar,
		User,
		ArrowLeft,
		Share2,
		Printer
	} from "lucide-svelte";

	let content: Content | null = null;
	let loading = true;
	let error = "";

	const id = $page.params.id;

	onMount(async () => {
		try {
			const response = await apiService.getContentById(id);
			if (response.success && response.data) {
				content = response.data;
			} else {
				error = response.message || "Content not found";
			}
		} catch (err) {
			error = "Failed to load update";
			console.error("Error loading content:", err);
		} finally {
			loading = false;
		}
	});

	function formatDate(dateString?: string) {
		if (!dateString) return "Recently";
		return new Date(dateString).toLocaleDateString("en-US", {
			year: "numeric",
			month: "long",
			day: "numeric",
			hour: '2-digit',
			minute: '2-digit'
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
	{#if content}
		<title>{content.title} - Alumni Network</title>
	{:else}
		<title>News & Updates - Alumni Network</title>
	{/if}
</svelte:head>

<div class="bg-gray-50 min-h-screen py-12">
	<div class="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8">
		<!-- Back Button -->
		<a href="/news" class="inline-flex items-center text-primary-600 hover:text-primary-700 font-medium mb-8 transition-colors group">
			<ArrowLeft class="w-5 h-5 mr-2 transition-transform group-hover:-translate-x-1" />
			Back to All Updates
		</a>

		{#if loading}
			<div class="bg-white rounded-2xl shadow-sm p-12 text-center">
				<div class="animate-spin rounded-full h-12 w-12 border-b-2 border-primary-600 mx-auto"></div>
				<p class="mt-4 text-gray-600">Loading update...</p>
			</div>
		{:else if error}
			<div class="bg-white rounded-2xl shadow-sm p-12 text-center">
				<div class="w-20 h-20 bg-red-50 text-red-500 rounded-full flex items-center justify-center mx-auto mb-6">
					<Bell class="w-10 h-10" />
				</div>
				<h2 class="text-2xl font-bold text-gray-900 mb-2">Something went wrong</h2>
				<p class="text-gray-600 mb-8">{error}</p>
				<a href="/news" class="btn-primary">Return to News</a>
			</div>
		{:else if content}
			<article class="bg-white rounded-2xl shadow-sm overflow-hidden">
				<!-- Header -->
				<header class="p-8 md:p-12 border-b border-gray-100">
					<div class="flex items-center space-x-4 mb-6">
						<span class="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium {getTypeColor(content.type)}">
							<svelte:component this={getIcon(content.type)} class="w-4 h-4 mr-1.5" />
							{getTypeLabel(content.type)}
						</span>
						<span class="text-sm text-gray-500 flex items-center">
							<Calendar class="w-4 h-4 mr-1.5" />
							{formatDate(content.publishDate)}
						</span>
					</div>

					<h1 class="text-3xl md:text-4xl font-extrabold text-gray-900 mb-6 leading-tight">
						{content.title}
					</h1>

					<div class="flex items-center justify-between">
						<div class="flex items-center">
							<div class="w-10 h-10 bg-primary-100 rounded-full flex items-center justify-center mr-3">
								<User class="w-6 h-6 text-primary-600" />
							</div>
							<div>
								<p class="text-sm font-bold text-gray-900">{content.creatorName}</p>
								<p class="text-xs text-gray-500">Author</p>
							</div>
						</div>

						<div class="flex items-center space-x-2">
							<button class="p-2 text-gray-400 hover:text-primary-600 hover:bg-primary-50 rounded-full transition-colors" title="Share">
								<Share2 class="w-5 h-5" />
							</button>
							<button onclick={() => window.print()} class="p-2 text-gray-400 hover:text-primary-600 hover:bg-primary-50 rounded-full transition-colors" title="Print">
								<Printer class="w-5 h-5" />
							</button>
						</div>
					</div>
				</header>

				<!-- Body -->
				<div class="p-8 md:p-12">
					<div class="prose prose-lg max-w-none text-gray-700 leading-relaxed whitespace-pre-line">
						{content.body}
					</div>
				</div>

				<!-- Footer -->
				<footer class="px-8 py-6 bg-gray-50 border-t border-gray-100 flex justify-between items-center">
					<p class="text-sm text-gray-500 italic">
						Last updated: {formatDate(content.updatedAt)}
					</p>
					<div class="flex space-x-4">
						<!-- Optional: social share buttons -->
					</div>
				</footer>
			</article>

			<!-- Related Content or CTA -->
			<div class="mt-12 bg-primary-600 rounded-2xl p-8 text-white flex flex-col md:flex-row items-center justify-between">
				<div class="mb-6 md:mb-0 md:mr-8">
					<h3 class="text-xl font-bold mb-2">Stay Updated</h3>
					<p class="text-primary-100">Never miss an update from our alumni network. Join us today!</p>
				</div>
				<div class="flex space-x-4">
					<a href="/auth/register" class="bg-white text-primary-600 hover:bg-primary-50 px-6 py-2 rounded-lg font-bold transition-colors">
						Join Now
					</a>
				</div>
			</div>
		{/if}
	</div>
</div>

<style>
	/* Print styles */
	@media print {
		:global(nav), :global(footer), .btn-primary, button, .bg-primary-600 {
			display: none !important;
		}
		.bg-gray-50 {
			background-color: white !important;
		}
		.shadow-sm {
			box-shadow: none !important;
		}
		.max-w-4xl {
			max-width: 100% !important;
		}
	}
</style>
