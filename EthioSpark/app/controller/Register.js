Ext.define('EthioSpark.controller.Register', {
    extend: 'Ext.app.Controller',

    config: {
        control: {
            cmdRegister: {
                tap: 'register'
            }
        },

        refs: {
            registrationFieldSet: 'customfieldset#fsRegistration',
            newUserGender: 'selectfield#cboNewUserGenderMode',
            newUserBday: 'datepickerfield#dpfNewUserBday',
            newUsername: 'textfield#txtNewUsername',
            newUserPassword: 'passwordfield#txtNewUserPassword',
            newUserConfirmPassword: 'passwordfield#txtNewUserConfirmPassword',
            newUserEmail: 'emailfield#txtNewUserEmail',
            cmdRegister: 'button[action=register]'
        }
    },

    validateData: function () {

    },

    register: function() {

        var regModel = Ext.create('EthioSpark.model.RegistrationInfo',
            {
                genderMode: this.getNewUserGender().getValue(),
                birthDate: this.getNewUserBday().getValue().getTime(),
                username: this.getNewUsername().getValue(),
                password: this.getNewUserPassword().getValue(),
                confirmPassword: this.getNewUserConfirmPassword().getValue(),
                email: this.getNewUserEmail().getValue()
            });
        var errors = regModel.validate();
        if (errors.getCount() > 0) {
            this.getRegistrationFieldSet().showErrorMessages(errors);
        }
        else 
        {
            this.getRegistrationFieldSet().setInstructions(null);
            regModel.saveInfo({
                scope: this,
                successJsonCallback:function() {
                    
                },
                errorJsonCallback: function(errors) {
                    this.getRegistrationFieldSet().showErrorMessages(errors);
                }
            });
        }
        regModel.destroy();
    }
});