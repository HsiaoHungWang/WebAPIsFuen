const CACHE_NAME = 'cache-v2';
const urlsToCache = ['/', '/abc.css', '/sw.js', '/index.html'];
self.addEventListener('install', function (event) {
    event.waitUntil(
        caches.open(CACHE_NAME).then(function (cache) {
            return cache.addAll(urlsToCache);
        })
    );
})

self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request).then(function (response) {
            return response || fetch(event.request);
        })
    );
})

self.addEventListener("activate", function (event) {
    event.waitUntil(
        caches.keys().then(function (names) {
            return Promise.all(names.map(function (name) {
                if (name != CACHE_NAME) {
                    return caches.delete(name)
                }
            }))
        })
    )
});


