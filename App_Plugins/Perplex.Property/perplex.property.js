angular.module("umbraco").component("perplexProperty", {
    templateUrl: "/App_Plugins/Perplex.Property/perplex.property.html",
    bindings: {
        key: "@",
        getValue: "&",
        setValue: "&",
        label: "@?",
        description: "@?",
    },
    controller: function perplexPropertyController(perplexPropertyCache) {
        this.property = null;

        this.$onChanges = function (changes) {
            if (changes.key && this.key) {
                perplexPropertyCache
                    .getScaffold(this.key)
                    .then(this.setScaffold.bind(this));
            }
        };

        this.setScaffold = function (scaffold) {
            this.property = scaffold;
            this.property.label = this.label;
            this.property.description = this.description;
            this.property.hideLabel = !this.property.label;

            Object.defineProperty(this.property, "value", {
                get: () => this.getValue(),
                set: value => this.setValue({ value: value }),
            });
        };
    },
});
