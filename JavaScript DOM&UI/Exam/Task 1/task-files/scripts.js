function createImagesPreviewer(selector, items) {
    var div = document.querySelector(selector),
        frame = document.createElement('div'),
        filter = document.createElement('input');

    div.style.width = '650px';
    frame.style.margin = '20px 5px';
    frame.style.width = '400px';
    frame.style.display='inline-block';

    function createMainFrame(frame, item) {
        var header = document.createElement('h1'),
            image = document.createElement('img');

        header.innerHTML = item.title;
        header.style.textAlign = 'center';
        header.id='animal-title';
        image.src = item.url;
        image.style.width = '400px';
        image.style.height = '300px';
        image.style.borderRadius = '15px';
        image.id='current';
        frame.appendChild(header);
        frame.appendChild(image);
        div.appendChild(frame);
    }

    function createSideBar(filter, items) {
        var sidebar = document.createElement('div'),
            filterHeader=document.createElement('h3');
        sidebar.style.width = '200px';
        sidebar.style.height = '427px';
        sidebar.style.overflow = 'auto';
        sidebar.style.float='right';
        sidebar.style.paddingLeft = '20px';
		sidebar.style.display='inline-block';
        filter.type = 'text';
        filter.style.marginLeft='15px';
        filterHeader.innerHTML='Filter';
        filterHeader.style.margin='0';
        filterHeader.style.padding='0';
        filterHeader.style.textAlign='center';
        filterHeader.style.fontWeight='normal';
        filter.addEventListener('keyup', filterAnimals);
        sidebar.appendChild(filterHeader);
        sidebar.appendChild(filter);


        for (var i = 0; i < items.length; i++) {
            var thumbnail = document.createElement('div'),
                header = document.createElement('h3'),
                image = document.createElement('img');
            header.innerHTML = items[i].title;
            header.style.textAlign = 'center';
            header.style.margin='0';
            header.style.padding='0';
            image.src = items[i].url;
            image.style.width = '150px';
            image.style.height = '100px';
            image.style.borderRadius = '10px';
            image.style.marginLeft = '15px';
            thumbnail.id=items[i].title.toLowerCase();
            thumbnail.className='animal';
            thumbnail.appendChild(header);
            thumbnail.appendChild(image);

            thumbnail.addEventListener('mouseover', function () {
                this.style.background = '#ccc';
            });

            thumbnail.addEventListener('mouseout', function () {
                this.style.background = '#fff';
            });

            thumbnail.addEventListener('click', function () {
                var frame = document.createElement('div');
                document.getElementById('current').src=this.getElementsByTagName('img')[0].src;
                document.getElementById('animal-title').innerHTML=this.getElementsByTagName('h3')[0].innerHTML;
        });

            sidebar.appendChild(thumbnail);
        }

        div.appendChild(sidebar);
    }


    function filterAnimals() {
        var val = this.value;
        var animals = document.getElementsByClassName('animal');
        if(val===''){
            for (var i = 0; i < animals.length; i++) {
                animals[i].style.display='block';
            }
        }else {
            for (var i = 0; i < animals.length; i++) {
                console.log(document.getElementById(animals[i].id));
                if (document.getElementById(animals[i].id).id.indexOf(val) === -1) {
                    document.getElementById(animals[i].id).style.display = 'none';
                }
            }
        }
    }

    createMainFrame(frame, items[0]);
    createSideBar(filter, items);
}