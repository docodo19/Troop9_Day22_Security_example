namespace Security1.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
        private blogResource;
        public blogs

        constructor($resource:angular.resource.IResourceService) {
            this.blogResource = $resource('/api/blog/:id');
            this.blogs = this.blogResource.query();
        }


    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
