window.localStorageInterop = {

    getItem: function (key) {
        let theme = localStorage.getItem(key);
        return theme
        
    }
};