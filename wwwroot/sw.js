const CACHE_NAME = "cache-v4";
const urlsToCatch = ['/', '/abc.css', '/xyz.css', '/index.html', '/sw.js'];
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
    event.waitUntil(
        caches.keys().then(function (names) {
            return Promise.all(names.map(function (name) {
                if (name != CACHE_NAME) {
                    return caches.delete(name);
                }
            }))
        })
    );
})
self.addEventListener('fetch', function (event) {
    console.log('fetch');
    event.respondWith(
        //
        //到Browser Cache 比對，成功會返回一個response物件
        caches.match(event.request).then(function (response) {
            //response有內容就直接回傳response
            //response沒有內容就透過Internet去要
            return response || fetch(event.request);
        })
    )
})