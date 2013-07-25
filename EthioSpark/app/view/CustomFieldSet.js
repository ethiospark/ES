Ext.define('EthioSpark.view.CustomFieldSet', {
    extend: 'Ext.form.FieldSet',
    xtype: 'customfieldset',
    initialize: function ()
    {
        this.add({
            xtype: 'container',
            itemId: 'cntErrorMessages',
            baseCls: this.getBaseCls() + '-instructions esRoundCorder',
            docked: 'bottom',
            hidden: true,
            layout: {
                    type: 'vbox',
                    align: 'center',
                    pack: 'center'
                }
        });
    },
    showErrorMessages: function (errors)
    {
        var cntErrorMessages = this.down('#cntErrorMessages');
        if (cntErrorMessages != null)
        {
            cntErrorMessages.removeAll(true, true);
            if (errors != null && errors.getCount() > 0)
            {
                for (var i = 0; i < errors.length; i++) {

                    cntErrorMessages.add({
                        html: errors.getAt(i).getMessage()
                    });
                }
                cntErrorMessages.show();
            }
            else
            {
                cntErrorMessages.hide();
            }
        }
    }
});
