Ext.define('EthioSpark.controller.Login', {
    extend: 'Ext.app.Controller',

    config: {
        control: {
            cmdLogin: {
                tap: 'login'
            },
            cmdSignUp: {
                tap: 'signUp'
            }
        },

        refs: {
            loginFieldSet: 'customfieldset#fsLogin',
            txtUsername: 'textfield#txtUsername',
            txtPassword: 'passwordfield#txtPassword',
            cmdLogin: 'button[action=login]',
            cmdSignUp: 'button[action=signup]'
        }
    },

    login: function() {
        Ext.Ajax.request({
            url: 'Account/Login',
            scope: this,
            params: {
                UserName: this.getTxtUsername().getValue(),
                Password: this.getTxtPassword().getValue()
            },
            successJson: function (loginResponse) {
                NvgView.replaceView(Ext.create('EthioSpark.view.Home'));
            },
            errorJson: function (errors)
            {
                this.getLoginFieldSet().showErrorMessages(errors);
            }
        });
    },
    signUp: function () {
        Ext.Ajax.request({
            url: 'Account/InitRegister',
            scope: this,
            successJson: function (initInfo) {
                NvgView.push(Ext.create('EthioSpark.view.Register', {
                    dobYearFrom: initInfo.data.dobYearFrom,
                    dobYearTo: initInfo.data.dobYearTo,
                    dobDefault: initInfo.data.dobDefault
                }));
            }
        });

    }
});