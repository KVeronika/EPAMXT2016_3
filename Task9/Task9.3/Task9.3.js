/**
 * Created by Veronika on 11/25/2016.
 */
(function () {
    var leftToRightAllBtn = document.getElementsByClassName('leftToRightAll'),
        leftToRightBtn = document.getElementsByClassName('leftToRight'),
        rightToLeftAllBtn = document.getElementsByClassName('rightToLeftAll'),
        rightToLeftBtn = document.getElementsByClassName('rightToLeft'),
        i;

    for (i = 0; i < leftToRightBtn.length; i++) {
        leftToRightAllBtn[i].onclick = moveAllToRight;
        leftToRightBtn[i].onclick = moveOneToRight;
        rightToLeftAllBtn[i].onclick = moveAllToLeft;
        rightToLeftBtn[i].onclick = moveOneToLeft;
    }

    function moveAllToRight(e) {
        var parentContainer = e.target.closest('.butterflyControls');
        moveAll(parentContainer, '.leftListItems', '.rightListItems');
    }
    function moveOneToRight(e) {
        var parentContainer = e.target.closest('.butterflyControls');
        moveOne(parentContainer, '.leftListItems', '.rightListItems');
    }
    function moveAllToLeft(e) {
        var parentContainer = e.target.closest('.butterflyControls');
        moveAll(parentContainer, '.rightListItems', '.leftListItems');
    }
    function moveOneToLeft(e) {
        var parentContainer = e.target.closest('.butterflyControls');
        moveOne(parentContainer, '.rightListItems', '.leftListItems');
    }

    function moveAll(parentContainer, sourceSelector, destinationSelector) {
        var source = parentContainer.querySelector(sourceSelector),
            destination = parentContainer.querySelector(destinationSelector),
            childsFirstList = source.options,
            i,
            temp;
        while(childsFirstList.length){
            temp = childsFirstList.item([i]);
            destination.appendChild(temp);
        }
    }
    function moveOne(parentContainer, sourceSelector, destinationSelector) {
        var source = parentContainer.querySelector(sourceSelector),
            destination = parentContainer.querySelector(destinationSelector),
            i,
            flag = false;
        for(i = 0; i < source.options.length; i++){
            if(source.options.item(i).selected){
                destination.appendChild(source.options.item(i));
                flag = true;
            }
        }
        if(!flag){
            alert('Nothing to move');
        }
        destination.selectedIndex = -1;
    }
})();