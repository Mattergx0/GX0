// service-worker.js
self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open('gx0-cache').then((cache) => {
            return cache.addAll([
                '/',
                '/index.html',
                '/style.css',
                '/app.js',
                '/icon.png'
            ]);
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((response) => {
            return response || fetch(event.request);
        })
    );
});
