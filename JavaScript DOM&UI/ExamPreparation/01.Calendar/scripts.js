function createCalendar(elemId,events) {
    function createRow(className) {
        var row = document.createElement('tr');
        row.style.border='1px solid black';
        row.className = className;

        if (className === 'row-content') {
            for (var i = 0; i < 7 && day < 31; day++, i++) {
                var someCol= document.createElement('td');
                someCol.style.border = '1px solid black';
                someCol.innerHTML = weekDay[i] + ' ' + day + ' June ' + ' 2014';
                someCol.style.background='#ccc';
                someCol.style.fontWeight = 'bold';
                someCol.style.textAlign = 'center';
                someCol.style.padding = '0 5px';
                someCol.addEventListener('mouseover', function () {
                    this.style.background='#909090';
                });
                someCol.addEventListener('mouseout', function () {
                    if(!this.className || this.className!=='selected'){
                        this.style.background='#ccc';
                    }
                });
                someCol.addEventListener('click', function () {
                    if(document.getElementsByClassName('selected')[0]) {
                        document.getElementsByClassName('selected')[0].style.background = '#ccc';
                        document.getElementsByClassName('selected')[0].className = '';
                    }
                    this.className='selected';
                    this.style.background='#fff';
                });
                row.appendChild(someCol);
            }
        } else {
            for (var a = 0; a < 7 && id < 31; id++, a++) {
                var col= document.createElement('td');
                col.style.border = '1px solid black';
                col.style.height='100px';
                col.style.verticalAlign ='text-top';
                col.id = id;
                row.appendChild(col);
            }
        }
        table.appendChild(row);
    }

    var table = document.createElement('table'),
        day = 1,
        id=1,
        weekDay = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    for(var i =0;i<10;i++){
        if(i%2===0){
            createRow('row-content');
        }else{
            createRow('row-header');
        }
    }
    table.style.border='1px solid black';
    table.style.borderCollapse='collapse';

    elemId=elemId.slice(1);
    document.getElementById(elemId).appendChild(table);


    for(var event=0; event<events.length;event++){
        var id = events[event].date;
        console.log(id);
        document.getElementById(id).innerHTML=events[event].hour+
            ' <strong>'+events[event].title+'</strong>';
    }

}