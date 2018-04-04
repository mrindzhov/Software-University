class TitleBar {
    constructor(title) {
        this.title = title;
        this.navigationLinks = []
    }

    addLink(href, name) {
        this.navigationLinks.push($(`<a class="menu-link" href="${href}">${name}</a>`))
    }

    appendTo(selector) {
        $(selector).append(this.generateHtml());
    }

    generateHtml() {
        let header = $(`
                <header class="header">
                    <div class="header-row">
                        <a class="button">&#9776;</a>
                        <span class="title">${this.title}</span>
                    </div>
                    <div class="drawer">
                        <nav class="menu">
                        </nav>
                    </div>
                </header>`);
        this.fillNavigation(header);

        let button = header.find('.button');
        this.menu = header.find('.menu');

        button.click(this.toggle.bind(this));
        return header;

    }

    fillNavigation(header) {
        let menuNav = header.find('.menu');
        for (let menu of this.navigationLinks) {
            $(menuNav).append(menu)
        }
    }

    toggle() {
        let menuNav = this.menu.parent();
        if (menuNav.css('display') === 'none') {
            menuNav.css('display', 'block');
        } else {
            menuNav.css('display', 'none');
        }
    }
}
