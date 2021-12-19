angular
    .module("umbraco")
    .service(
        "perplexPropertyCache",
        function (contentTypeResource, dataTypeResource) {
            var cache = {}; // key -> scaffold

            this.getScaffold = function (key) {
                var cached = cache[key];
                if (cached == null) {
                    cached = cache[key] = dataTypeResource
                        .getById(key)
                        .then(dataType =>
                            contentTypeResource.getPropertyTypeScaffold(
                                dataType.id
                            )
                        );
                }
                return cached.then(scaffold => angular.copy(scaffold));
            };
        }
    );
