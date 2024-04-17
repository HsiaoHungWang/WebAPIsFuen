const CACHE_NAME = "cache-v1";
const urlsToCatch = ['/', '/abc.css', '/index.html', '/sw.js'];
self.addEventListener('install', function (event) {
    console.log('install');
    event.waitUntil(
        caches.open(CACHE_NAME).then(function (cache) {
            return cache.addAll(urlsToCatch);
        })
    );
})
self.addEventListener('activate', function (event) {
    console.log('activate');
})
self.addEventListener('fetch', function (event) {
    console.log('fetch');
})