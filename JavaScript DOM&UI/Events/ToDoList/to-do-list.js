window.onload = function () {
    var task = document.getElementById('task'),
        addBtn = document.getElementById('add-btn'),
        showBtn = document.getElementById('hide-show-btn'),
        toDoList = document.getElementById('to-do-list');

    addBtn.addEventListener('click', onAddTaskBtnClick);
    showBtn.addEventListener('click', onShowHideBtnClick);

    function onAddTaskBtnClick() {
        var taskElem = document.createElement('div'),
            removeBtn = document.createElement('input'),
            taskText = document.createElement('span');

        taskText.innerHTML = task.value;
        removeBtn.type = 'button';
        removeBtn.value = 'x'
        removeBtn.addEventListener('click', onRemoveBtnClick);
        taskElem.appendChild(removeBtn);
        taskElem.appendChild(taskText);
        
        toDoList.appendChild(taskElem);
    }

    function onRemoveBtnClick(e) {
        var elementToRemove = e.target.parentNode;
        toDoList.removeChild(elementToRemove);
    }

    function onShowHideBtnClick(e) {
        if (e.target.value === 'Hide list') {
            e.target.value = 'Show list';
        } else {
            e.target.value = 'Hide list';
        }
        
        if (toDoList.style.display === 'block') {
            toDoList.style.display = 'none';
        } else {
            toDoList.style.display = 'block';
        }
    }
}