angular.module("BondSystemApp", ["smart-table", "ui.bootstrap"]).controller("BondController", function ($scope, $http) {
  var searchFilters = {
    currentPage: 1
    , pageSize: 10
    , totalResults: 0
    , itemsByPage: 10

    , bondId: null
    , ipCode: null
    , factoryId: null
    , productLineId: null
    , withOriginalEquipment: false
    , marketSegmentId: null
    , reasonTypeId: null
    , bondStatusId: null
    , userId: null
    , pendingQuantity: null
  };

  var search = function (filters, scrollOnResults) {
    /// <summary>Search bonds by filters</summary>
    /// <param name="filters">Filters</param>
    /// <param name="scrollOnResults">True, scroll on results table</param>
    $http.post("/bond/search", filters)
      .success(function (data, status, headers, config) {
        if (!data.hasErrors) {
          // Loads results
          $scope.bondResults = data.results.$values;
          // Loads pagination values
          $scope.searchFilters.totalResults = data.totalResults;
          // Scroll to results table
          scrollOnResults && common.scrollTo("#searchResults");
        } else
          $("#modal").modal("show");
      })
      .error(function (data, status, headers, config) {
        $("#modal").modal("show");
      });
  };

  $scope.searchFilters = searchFilters;
  $scope.clearFilters = function (filters) {
    /// <summary>Clear search filters</summary>
    /// <param name="filters">Filters</param>
    var oldPageSize = filters.pageSize;
    for (var p in filters) {
      if (filters.hasOwnProperty(p)) {
        filters[p] = null;
      }
    }

    // Restore pagination filters
    filters.currentPage = 1;
    filters.pageSize = oldPageSize;
    filters.itemsByPage = 10;
    filters.totalResults = 0;
  };

  $scope.search = function (filters, scrollOnResults) {
    // Restore pagination filters and search bonds
    filters.currentPage = 1;
    filters.itemsByPage = 10;
    filters.totalResults = 0;
    search(filters, scrollOnResults);
  };

  $scope.pagedSearch = function (filters) {
    search(filters);
  };

  $scope.changePageSize = function (selectedPageSize, filters) {
    /// <summary>Change page size and call server to find results</summary>
    /// <param name="selectedPageSize" type="int">New page size</param>
    /// <param name="filters">Search filters</param>
    filters.pageSize = selectedPageSize;
    // Loads bond results
    $scope.search(filters);
  };

  $scope.getBondById = function (bondId) {
    window.open("/Bond/Details/" + bondId, "_self");
  };

  // Loads bond results
  $scope.bondResults = [];
  $scope.search(searchFilters);
})
  .directive("onSearchResultsRepeatComplete", function () {
    return function (scope, element, attrs) {
      if (scope.$last) {
        $('[data-toggle="tooltip"]').tooltip({
          delay: { "show": 500 }
        });
      }
    }
  });;