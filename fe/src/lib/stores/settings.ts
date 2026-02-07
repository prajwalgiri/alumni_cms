import { writable } from 'svelte/store';
import { apiService, type SystemSetting } from '$lib/api';

interface ThemePalette {
    [key: string]: string;
}

const themes: Record<string, ThemePalette> = {
    blue: {
        '--primary-50': '#eff6ff',
        '--primary-100': '#dbeafe',
        '--primary-200': '#bfdbfe',
        '--primary-300': '#93c5fd',
        '--primary-400': '#60a5fa',
        '--primary-500': '#3b82f6',
        '--primary-600': '#2563eb',
        '--primary-700': '#1d4ed8',
        '--primary-800': '#1e40af',
        '--primary-900': '#1e3a8a',
    },
    indigo: {
        '--primary-50': '#eef2ff',
        '--primary-100': '#e0e7ff',
        '--primary-200': '#c7d2fe',
        '--primary-300': '#a5b4fc',
        '--primary-400': '#818cf8',
        '--primary-500': '#6366f1',
        '--primary-600': '#4f46e5',
        '--primary-700': '#4338ca',
        '--primary-800': '#3730a3',
        '--primary-900': '#312e81',
    },
    red: {
        '--primary-50': '#fef2f2',
        '--primary-100': '#fee2e2',
        '--primary-200': '#fecaca',
        '--primary-300': '#fca5a5',
        '--primary-400': '#f87171',
        '--primary-500': '#ef4444',
        '--primary-600': '#dc2626',
        '--primary-700': '#b91c1c',
        '--primary-800': '#991b1b',
        '--primary-900': '#7f1d1d',
    },
    emerald: {
        '--primary-50': '#ecfdf5',
        '--primary-100': '#d1fae5',
        '--primary-200': '#a7f3d0',
        '--primary-300': '#6ee7b7',
        '--primary-400': '#34d399',
        '--primary-500': '#10b981',
        '--primary-600': '#059669',
        '--primary-700': '#047857',
        '--primary-800': '#065f46',
        '--primary-900': '#064e3b',
    }
};

function createSettingsStore() {
    const { subscribe, set, update } = writable<{
        settings: SystemSetting[];
        isLoading: boolean;
        error: string | null;
    }>({
        settings: [],
        isLoading: false,
        error: null
    });

    return {
        subscribe,
        init: async () => {
            update(s => ({ ...s, isLoading: true }));
            try {
                const result = await apiService.getSettings();

                if (result.success && result.data) {
                    const settings = result.data;
                    set({ settings, isLoading: false, error: null });

                    // Apply theme
                    const themeSetting = settings.find(s => s.key === 'Theme');
                    if (themeSetting) {
                        applyTheme(themeSetting.value);
                    }
                } else {
                    update(s => ({ ...s, isLoading: false, error: result.message || 'Failed to fetch settings' }));
                }
            } catch (err: any) {
                update(s => ({ ...s, isLoading: false, error: err.message }));
            }
        },
        updateSetting: async (key: string, value: string) => {
            try {
                const result = await apiService.updateSetting(key, value);
                if (result.success) {
                    update(s => {
                        const newSettings = s.settings.map(st =>
                            st.key === key ? { ...st, value } : st
                        );
                        if (key === 'Theme') {
                            applyTheme(value);
                        }
                        return { ...s, settings: newSettings };
                    });
                    return { success: true };
                }
                return { success: false, message: result.message };
            } catch (err: any) {
                return { success: false, message: err.message };
            }
        }
    };
}

function applyTheme(themeName: string) {
    if (typeof document === 'undefined') return;

    const palette = themes[themeName] || themes.blue;
    const root = document.documentElement;

    Object.entries(palette).forEach(([property, value]) => {
        root.style.setProperty(property, value);
    });
}

export const settingsStore = createSettingsStore();
