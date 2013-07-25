Ext.define('EthioSpark.model.RegistrationInfo', {
    extend: 'Ext.data.Model',
    alias: 'model.User',
    config: {
        fields: [
            { name: 'genderMode', type: 'int' },
            { name: 'birthDate', type: 'int' },
            { name: 'username', type: 'string' },
            { name: 'password', type: 'string' },
            { name: 'confirmPassword', type: 'string' },
            { name: 'email', type: 'string' }
        ],
        validations: [
                      { type: 'presence', field: 'username', message: StrRes.NoUsername[locale] },
                      { type: 'presence', field: 'password', message: StrRes.NoPassword[locale] },
                      { type: 'presence', field: 'confirmPassword', message: StrRes.NoPasswordConfirmation[locale] },
                      { type: 'presence', field: 'email', message: StrRes.NoEmail[locale] }
                    ]
    },
    validate: function ()
    {
        var errors = this.callParent();
        //if email address is provide, check if its valid.
        if (errors.getByField('email').length == 0) {
            if (!Ext.data.validations.emailRe.test(this.get('email'))) {
                errors.add(Ext.create('Ext.data.Error', {
                    field: 'email',
                    message: StrRes.InvalidEmail[locale]
                }));
            }
        }
        //check if password matches confirmation.
        if (errors.getByField('password').length == 0 &&
            errors.getByField('confirmPassword').length == 0)
        {
            if (this.get('password') != this.get('confirmPassword'))
            {
                errors.add(Ext.create('Ext.data.Error', {
                    field: 'password',
                    message: StrRes.PasswordConfirmationNotMatching[locale]
                }));
            }
        }
        return errors;
    },

    saveInfo: function (callbackObj)
    {

        var callbackScope = this;
        if (callbackObj && callbackObj.scope)
            callbackScope = callbackObj.scope;

        Ext.Ajax.request({
            url: 'Account/Register',
            scope: callbackScope,
            params: this.getData(),
            successJson: callbackObj != null ? callbackObj.successJsonCallback : null,
            errorJson: callbackObj != null ? callbackObj.errorJsonCallback : null
        });
    }

});