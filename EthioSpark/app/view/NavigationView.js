Ext.define('EthioSpark.view.NavigationView', {
    extend: 'Ext.NavigationView',
    fullscreen: true,
    singleton: true,
    replaceView: function (newView, removeAllOtherViews) {
        if (removeAllOtherViews == true) {
            this.removeAll(true, true);
        }
        else 
        {
            //remove the last view.
            this.pop();
        }
        
        this.push(newView);
    }
});
