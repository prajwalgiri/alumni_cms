<script lang="ts">
    import { onMount } from 'svelte';
    import { settingsStore } from '$lib/stores/settings';
    import { Palette, Check, Loader2 } from 'lucide-svelte';

    let selectedTheme = 'blue';
    let isSaving = false;
    let message = '';
    let isError = false;

    $: themeSetting = $settingsStore.settings.find(s => s.key === 'Theme');

    $: if (themeSetting && !isSaving) {
        selectedTheme = themeSetting.value;
    }

    onMount(() => {
        settingsStore.init(); // Load all settings for admin
    });

    const themes = [
        { id: 'blue', name: 'Blue', class: 'bg-blue-600' },
        { id: 'indigo', name: 'Indigo', class: 'bg-indigo-600' },
        { id: 'red', name: 'Red', class: 'bg-red-600' },
        { id: 'emerald', name: 'Emerald', class: 'bg-emerald-600' },
        { id: 'maroon', name: 'Maroon', class: 'bg-[#af2a2c]' }
    ];

    $: logoSetting = $settingsStore.settings.find(s => s.key === 'LogoUrl');
    $: faviconSetting = $settingsStore.settings.find(s => s.key === 'FaviconUrl');
    $: siteNameSetting = $settingsStore.settings.find(s => s.key === 'SiteName');

    let logoUrl = '';
    let faviconUrl = '';
    let siteName = '';

    $: if (logoSetting) logoUrl = logoSetting.value;
    $: if (faviconSetting) faviconUrl = faviconSetting.value;
    $: if (siteNameSetting) siteName = siteNameSetting.value;

    async function handleSave() {
        isSaving = true;
        message = '';

        try {
            const results = await Promise.all([
                settingsStore.updateSetting('Theme', selectedTheme),
                settingsStore.updateSetting('LogoUrl', logoUrl),
                settingsStore.updateSetting('FaviconUrl', faviconUrl),
                settingsStore.updateSetting('SiteName', siteName)
            ]);

            const allSuccess = results.every(r => r.success);

            if (allSuccess) {
                message = 'Settings updated successfully!';
                isError = false;
            } else {
                message = 'Some settings failed to update';
                isError = true;
            }
        } catch (err) {
            message = 'An error occurred while saving';
            isError = true;
        } finally {
            isSaving = false;
        }
    }
</script>

<svelte:head>
    <title>System Settings - Admin Panel</title>
</svelte:head>

<div class="space-y-6">
    <div>
        <h1 class="text-2xl font-bold text-gray-900">System Settings</h1>
        <p class="text-gray-600 mt-1">Configure global application settings and appearance</p>
    </div>

    <div class="max-w-4xl space-y-6">
        <div class="card">
            <div class="flex items-center space-x-2 mb-6">
                <Palette class="w-6 h-6 text-primary-600" />
                <h3 class="text-lg font-semibold text-gray-900">Branding & Appearance</h3>
            </div>

            <div class="space-y-6">
                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                    <div>
                        <label class="form-label" for="siteName">Site Name</label>
                        <input
                            type="text"
                            id="siteName"
                            bind:value={siteName}
                            class="input-field"
                            placeholder="Enter site name"
                        />
                    </div>
                    <div>
                        <label class="form-label" for="logoUrl">Logo URL</label>
                        <div class="flex space-x-2">
                            <input
                                type="text"
                                id="logoUrl"
                                bind:value={logoUrl}
                                class="input-field flex-1"
                                placeholder="/assets/logo.png"
                            />
                            {#if logoUrl}
                                <div class="w-10 h-10 border rounded flex items-center justify-center bg-gray-50">
                                    <img src={logoUrl} alt="Logo preview" class="max-w-full max-h-full object-contain" />
                                </div>
                            {/if}
                        </div>
                    </div>
                    <div>
                        <label class="form-label" for="faviconUrl">Favicon URL</label>
                        <input
                            type="text"
                            id="faviconUrl"
                            bind:value={faviconUrl}
                            class="input-field"
                            placeholder="/favicon.ico"
                        />
                    </div>
                </div>

                <div class="pt-6 border-t border-gray-100">
                <div>
                    <label class="form-label font-bold">Primary Color Theme</label>
                    <p class="text-sm text-gray-600 mb-4">Choose the primary color scheme for the entire application.</p>

                    <div class="grid grid-cols-2 sm:grid-cols-4 gap-4">
                        {#each themes as theme}
                            <button
                                onclick={() => selectedTheme = theme.id}
                                class="relative flex flex-col items-center p-4 rounded-xl border-2 transition-all duration-200 {selectedTheme === theme.id ? 'border-primary-600 bg-primary-50' : 'border-gray-200 hover:border-gray-300 bg-white'}"
                            >
                                <div class="w-12 h-12 {theme.class} rounded-full mb-2 shadow-sm"></div>
                                <span class="text-sm font-medium text-gray-900">{theme.name}</span>

                                {#if selectedTheme === theme.id}
                                    <div class="absolute top-2 right-2 bg-primary-600 rounded-full p-0.5">
                                        <Check class="w-3 h-3 text-white" />
                                    </div>
                                {/if}
                            </button>
                        {/each}
                    </div>
                </div>

                <div class="pt-6 border-t border-gray-100 flex items-center justify-between">
                    <div>
                        {#if message}
                            <p class="text-sm {isError ? 'text-red-600' : 'text-green-600'} font-medium">
                                {message}
                            </p>
                        {/if}
                    </div>
                    <button
                        onclick={handleSave}
                        disabled={isSaving || (selectedTheme === themeSetting?.value && logoUrl === logoSetting?.value && faviconUrl === faviconSetting?.value && siteName === siteNameSetting?.value)}
                        class="btn-primary flex items-center space-x-2 disabled:opacity-50 disabled:cursor-not-allowed"
                    >
                        {#if isSaving}
                            <Loader2 class="w-4 h-4 animate-spin" />
                            <span>Saving...</span>
                        {:else}
                            <span>Save Changes</span>
                        {/if}
                    </button>
                </div>
            </div>
        </div>
    </div>
</div>
