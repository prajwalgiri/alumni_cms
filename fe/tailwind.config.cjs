/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{html,js,svelte,ts}'],
  theme: {
    extend: {
      colors: {
        primary: {
          50: 'var(--primary-50, #eff6ff)',
          100: 'var(--primary-100, #dbeafe)',
          200: 'var(--primary-200, #bfdbfe)',
          300: 'var(--primary-300, #93c5fd)',
          400: 'var(--primary-400, #60a5fa)',
          500: 'var(--primary-500, #3b82f6)',
          600: 'var(--primary-600, #2563eb)',
          700: 'var(--primary-700, #1d4ed8)',
          800: 'var(--primary-800, #1e40af)',
          900: 'var(--primary-900, #1e3a8a)',
        },
        secondary: {
          50: '#f8fafc',
          100: '#f1f5f9',
          200: '#e2e8f0',
          300: '#cbd5e1',
          400: '#94a3b8',
          500: '#64748b',
          600: '#475569',
          700: '#334155',
          800: '#1e293b',
          900: '#0f172a',
        }
      },
      fontFamily: {
        sans: ['Inter', 'system-ui', 'sans-serif'],
      },
    },
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
  ],
}
