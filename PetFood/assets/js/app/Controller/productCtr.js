petFood.controller('productController', ['$scope', '$http', '$cookies', function ($scope, $http, $cookies) {
    //  today + 2 day date.
    var expireDate = new Date();
    expireDate.setDate(expireDate.getDate() + 2);

    //default count is 0 and guest loginid is 0
    $scope.itemCount = 0;
    $scope.WishlistCount = 0;
    var loginId = 0;

   //check exiting user is active or not 
    var loginDetail = $cookies.get('loginDetails');
    if (typeof (loginDetail) != "undefined") {
        var loginData = JSON.parse(loginDetail);
        loginId = loginData.Id;
    }

     // add to cart count 
    var existCookies = $cookies.get('AddToCart' + loginId);
    if (typeof (existCookies) != "undefined") {
        var existCookesid = existCookies.split('-');
        $scope.itemCount = existCookesid.length;
    }
    // wishlist item count 
    var existCookies = $cookies.get('WishlistCookies' + loginId);
    if (typeof (existCookies) != "undefined") {
        var existCookesid = existCookies.split('-');
        $scope.WishlistCount = existCookesid.length;
    }
   
    $scope.ProductList = function () {

        var loginDetail = $cookies.get('loginDetails');

        if (typeof (loginDetail) != "undefined") {
            var loginData = JSON.parse(loginDetail);
            $scope.name = "Hi " + loginData.Name;
            $scope.Logout = "Logout";
            $scope.hide = "hide";
        }
        //logout function
        $scope.logoutUser = function () {
            $cookies.remove("loginDetails", { path: "/" });
            $scope.hide = "";
            $scope.Logout = "";
            $scope.name = "";
            window.location.reload();
        }
        //load all products 
        $scope.Products = [];
        $http.get('/Product/GetProducts').then(function (result) {
            $scope.Products = result.data;
        });

        //sort product by lowtohigh or highTolow 
        $scope.lowTohigh = function () {
            var featureValue = $scope.features.select;
            if (featureValue != "") {
                $http.post('/Product/SortProducts', { FeatureValue: featureValue }).then(function (response) {
                    $scope.Products = response.data;
                });
            }
        }
        // go to productPageDetail;
        $scope.productDeatil = function (ProductId) {
            var productID = ProductId;
            window.location.href = "/Product/ProductDetail?name=" + productID;
        }
       
    }


    //add to addtocart btn
    var addtocart;
    $scope.AddToCart = function (ProductId) {
        var loginId = 0;
        if (typeof (loginDetail) != "undefined") {
            var loginData = JSON.parse(loginDetail);
            loginId = loginData.Id;
        }

        var existCookies = $cookies.get('AddToCart' + loginId);
        if (existCookies != undefined) {
            addtocart = existCookies.split('-');
        } else {
            addtocart = [];
        }
        addtocart.push(ProductId);
        $cookies.put('AddToCart' + loginId, addtocart.join("-"), { path: '/', 'expires': expireDate });
        //count item addTocart
        var existCookies = $cookies.get('AddToCart' + loginId);
        if (typeof (existCookies) != "undefined") {
            var existCookesid = existCookies.split('-');
            $scope.itemCount = existCookesid.length;
        }
    }

    // add to wishlist btn
    var Wishlist;
    $scope.Wishlist = function (ProductId) {

        var loginId = 0;
        if (typeof (loginDetail) != "undefined") {
            var loginData = JSON.parse(loginDetail);
            loginId = loginData.Id;
        }

        var existCookies = $cookies.get('WishlistCookies' + loginId);
        if (existCookies != undefined) {
            Wishlist = existCookies.split('-');
        } else {
            Wishlist = [];
        }
        Wishlist.push(ProductId);
        $cookies.put('WishlistCookies' + loginId, Wishlist.join("-"), { path: '/', 'expires': expireDate });
        //wishlist item count 
        var existCookies = $cookies.get('WishlistCookies' + loginId);
        if (typeof (existCookies) != "undefined") {
            var existCookesid = existCookies.split('-');
            $scope.WishlistCount = existCookesid.length;
        }
    }

        // ProductDetail page 
    $scope.ProductDetail = function () {
       
        const params = new Proxy(new URLSearchParams(window.location.search), {
            get: (searchParams, prop) => searchParams.get(prop),
        });
        var productID = params.name;
        $http.post('/Product/ProductDetail', { productID: productID }).then(function (response) {
            $scope.productDetail = response.data;
            $scope.productPageDetail = { Title: $scope.productDetail[0].Title, Rating: "5", Price: $scope.productDetail[0].Price, Image: $scope.productDetail[0].Image, Image_one: $scope.productDetail[0].Image_one, Image_two: $scope.productDetail[0].Image_two, Hover_Image: $scope.productDetail[0].Hover_Image, Id: $scope.productDetail[0].Id };

        });
        $scope.Products = [];
        $http.get('/Product/GetProducts').then(function (result) {
            $scope.Products = result.data;

            //$scope.Product = [{ Title: $scope.dataList[0].Title, Rating: "5", Price: "$" + $scope.dataList[0].Price, Image: $scope.dataList[0].Image }];
        });
    }


    //addToBasket page 
    $scope.AddToBasket = function () {
        var loginDetail = $cookies.get('loginDetails');
        var loginId = 0;
        if (typeof (loginDetail) != "undefined") {
            var loginData = JSON.parse(loginDetail);
             loginId = loginData.Id;
        }
       
        //add to cart
        var addtocartcookiesName = "AddToCart" + loginId;
        var wishlistitemName = "WishlistCookies" + loginId;
        $scope.addtocarts = [];
        $scope.Totalprice = 0;
        $http.post('/Product/AddToBasket', { name: addtocartcookiesName }).then(function (result) {
            $scope.addtocarts = result.data;
            angular.forEach($scope.addtocarts, function (value) {
                $scope.Totalprice = $scope.Totalprice + value.Price;
            });

        });

        $scope.deleteCartId = function (id) {

            var existCookies = $cookies.get('AddToCart' + loginId);
            var existCookesid = existCookies.split('-');
            var arry = []
            existCookesid.map(arr => {
                arry.push(parseInt(arr))
            });
            arry = arry.filter(item => item !== id)
            if (arry.length > 0) {
                $cookies.put('AddToCart' + loginId, arry.join("-"), { path: '/', 'expires': expireDate });
                $http.post('/Product/AddToBasket', { name: addtocartcookiesName }).then(function (result) {
                    $scope.addtocarts = result.data;
                    $scope.Totalprice = 0;
                    angular.forEach($scope.addtocarts, function (value) {
                        $scope.Totalprice = $scope.Totalprice + value.Price;
                    });
                });
            }
            else {
                $cookies.remove("AddToCart" + loginId, { path: "/" });
                $http.post('/Product/AddToBasket', { name: addtocartcookiesName }).then(function (result) {
                    $scope.addtocarts = result.data;
                    $scope.Totalprice = 0;
                });
            }
            // addtocart count
            var existCookies = $cookies.get('AddToCart' + loginId);
            if (typeof (existCookies) != "undefined") {
                var existCookesid = existCookies.split('-');
                $scope.itemCount = existCookesid.length;
            } else {
                $scope.itemCount = 0;
            }

        }



        //wishlist cart

        $scope.wishlists = [];

        $http.post('/Product/AddToBasket', { name: wishlistitemName }).then(function (result) {
            $scope.wishlists = result.data;
        });
        //delete wishlist item
        $scope.DeleteWishlistItem = function (id) {

            var existCookies = $cookies.get('WishlistCookies' + loginId);
            var existCookesid = existCookies.split('-');
            var arry = []
            existCookesid.map(arr => {
                arry.push(parseInt(arr))
            });
            arry = arry.filter(item => item !== id)
            if (arry.length > 0) {
                $cookies.put('WishlistCookies' + loginId, arry.join("-"), { path: '/', 'expires': expireDate });
                $http.post('/Product/AddToBasket', { name: wishlistitemName }).then(function (result) {
                    $scope.wishlists = result.data;
                });
            }
            else {
                $cookies.remove("WishlistCookies" + loginId, { path: "/" });
                $http.post('/Product/AddToBasket', { name: wishlistitemName }).then(function (result) {
                    $scope.wishlists = result.data;
                });
            }
            //wishlist item count 
            var existCookies = $cookies.get('WishlistCookies' + loginId);
            if (typeof (existCookies) != "undefined") {
                var existCookesid = existCookies.split('-');
                $scope.WishlistCount = existCookesid.length;
            }
            else {
                $scope.WishlistCount = 0;
            }

        }
    }

}]);