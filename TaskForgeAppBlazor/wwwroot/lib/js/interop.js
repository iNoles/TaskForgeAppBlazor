window.taskForge = {
registerDragAndDrop: function (listId, dotNetRef) {
    const list = document.getElementById(listId);
    if (!list) return;
    
    let dragEl = null;
    
    list.querySelectorAll('.draggable').forEach(function(el) {
        el.draggable = true;
        el.addEventListener('dragstart', function(e) {
            dragEl = el;
            e.dataTransfer.setData('text/plain', '');
            el.classList.add('dragging');
        });
        
        el.addEventListener('dragend', function(e) {
            el.classList.remove('dragging');
            dragEl = null;
        });
        
        el.addEventListener('dragover', function(e) {
            e.preventDefault();
            const target = e.currentTarget;
            if (target !== dragEl) {
                const rect = target.getBoundingClientRect();
                const next = (e.clientY - rect.top) > rect.height / 2;
                if (next) {
                    target.parentNode.insertBefore(dragEl, target.nextSibling);
                } else {
                    target.parentNode.insertBefore(dragEl, target);
                }
            }
        });
        
        el.addEventListener('drop', function() {
            const ids = Array.from(list.querySelectorAll('.draggable')).map(function(x) { return x.getAttribute('data-id'); });
            dotNetRef.invokeMethodAsync('OnReorder', ids);
        });
    });
},

notify: function (title, options) {
    if ('Notification' in window && Notification.permission === 'granted') {
        new Notification(title, options);
    }
}};