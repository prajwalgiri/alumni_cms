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

    const themes = [
        { id: 'blue', name: 'Blue', class: 'bg-blue-600' },
        { id: 'indigo', name: 'Indigo', class: 'bg-indigo-600' },
        { id: 'red', name: 'Red', class: 'bg-red-600' },
        { id: 'emerald', name: 'Emerald', class: 'bg-emerald-600' }
    ];

    async function handleSave() {
        isSaving = true;
        message = '';
        const result = await settingsStore.updateSetting('Theme', selectedTheme);
        isSaving = false;

        if (result.success) {
            message = 'Theme updated successfully!';
            isError = false;
        } else {
            message = result.message || 'Failed to update theme';
            isError = true;
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

    <div class="max-w-4xl">
        <div class="card">
            <div class="flex items-center space-x-2 mb-6">
                <Palette class="w-6 h-6 text-primary-600" />
                <h3 class="text-lg font-semibold text-gray-900">Appearance Settings</h3>
            </div>

            <div class="space-y-6">
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
                        disabled={isSaving || selectedTheme === themeSetting?.value}
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
