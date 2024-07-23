/** @type {import('tailwindcss').Config} */
const { iconifyPlugin } = require('@iconify/tailwind');

module.exports = {
  content: [
    './Views/**/*.cshtml',
    './Views/Shared/**/*.cshtml', // Captura los archivos de Shared también
    './wwwroot/**/*.js', // Asegura que Tailwind se aplique a los archivos JS
    './**/*.html', // Captura todos los archivos HTML en el proyecto
    './**/*.js', // Captura todos los archivos JS en el proyecto
    "./node_modules/flowbite/**/*.js" // Asegura que Flowbite se aplique
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
    iconifyPlugin()   
  ]
}
