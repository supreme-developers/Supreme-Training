angular.module('ssi.sortable', [])
  .value('ssiSortableConfig', {
      placeholder: "placeholder",
      opacity: 0.8,
      axis: "y",
      helper: 'clone',
      forcePlaceholderSize: true
  })
  .directive("ssiSortable", ['ssiSortableConfig', '$log', function (ssiSortableConfig, $log) {
      return {
          require: '?ngModel',
          link: function (scope, element, attrs, ngModel) {

              if (!ngModel) {
                  $log.error('ssiSortable needs a ng-model attribute!', element);
                  return;
              }
              var opts = {};
              angular.extend(opts, ssiSortableConfig);
              opts.update = update;
              
              // listen for changes on ssiSortable attribute
              scope.$watch(attrs.ssiSortable, function (newVal) {                 
                  angular.forEach(newVal, function (value, key) {
                      element.sortable('option', key, value);
                      console.log('k' + key);
                      console.log('v' + value);
                  });
              }, true);

              // store the sortable index
              scope.$watch(attrs.ngModel + '.length', function () {                  
                  element.children().each(function (i, elem) {
                      jQuery(elem).attr('sortable-index', i);
                      
                  });
              });

              // jQuery sortable update callback
              function update(event, ui) {
                  scope.Taskdropped = scope.Taskdropped + 1; //this variable tells me an Item has been dropped.
                  
                  // get model                 
                  var model = ngModel.$modelValue;
                  console.log(ui.item.data('start', ui.item.index()));
                  console.log(ui.item.index());
                  // remember its length
                  var modelLength = model.length;
                  // rember html nodes
                  var items = [];
                  // loop through items in new order
                  element.children().each(function (index) {
                      var item = jQuery(this);                      
                      // get old item index
                      var oldIndex = parseInt(item.attr("sortable-index"), 10);

                      // add item to the end of model
                      model.push(model[oldIndex]);

                      if (item.attr("sortable-index")) {
                          // items in original order to restore dom
                          items[oldIndex] = item;
                          // and remove item from dom
                          item.detach();
                      }
                  });

                  model.splice(0, modelLength);
                  
                 
                  // restore original dom order, so angular does not get confused
                  element.append.apply(element, items);

                  // notify angular of the change
                  scope.$digest();
              }

              element.sortable(opts);
          }
      };
  }]);