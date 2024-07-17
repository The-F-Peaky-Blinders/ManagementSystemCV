/** @type {import('tailwindcss').Config} */

module.exports = {
  content: [
    './Views/**/*.cshtml',
    './Components/**/*.cshtml',
    './wwwroot/**/*.js',
    "./node_modules/flowbite/**/*.js"
  ],
  darkMode: 'class',
  theme: {
    extend: {
      colors: {
        primary: {
          "50": "#ecefff",
          "100": "#dde1ff",
          "200": "#c2c8ff",
          "300": "#9ca3ff",
          "400": "#7875ff",
          "500": "#6b5cff",
          "600": "#5736f5",
          "700": "#4b2ad8",
          "800": "#3d25ae",
          "900": "#342689",
          "950": "#211650"
        }
      },
      fontFamily: {
        'body': [
          'Inter',
          'ui-sans-serif',
          'system-ui',
          '-apple-system',
          'system-ui',
          'Segoe UI',
          'Roboto',
          'Helvetica Neue',
          'Arial',
          'Noto Sans',
          'sans-serif',
          'Apple Color Emoji',
          'Segoe UI Emoji',
          'Segoe UI Symbol',
          'Noto Color Emoji'
        ],
        'sans': [
          'Inter',
          'ui-sans-serif',
          'system-ui',
          '-apple-system',
          'system-ui',
          'Segoe UI',
          'Roboto',
          'Helvetica Neue',
          'Arial',
          'Noto Sans',
          'sans-serif',
          'Apple Color Emoji',
          'Segoe UI Emoji',
          'Segoe UI Symbol',
          'Noto Color Emoji'
        ]
      }
    }
  },
  plugins: [
    require('flowbite/plugin'),
    require('@iconify/tailwind')
  ]
}
