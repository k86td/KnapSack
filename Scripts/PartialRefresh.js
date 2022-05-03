class PartialRefresh {
    constructor(serviceURL, container, refreshRate, callback = null) {
        this.serviceURL = serviceURL;
        this.container = container;
        this.callback = callback;
        this.refreshRate = refreshRate * 1000;
        this.paused = false;
        this.refresh(true);
        setInterval(() => { this.refresh() }, this.refreshRate);
    }
    pause() { this.paused = true }
    restart() { this.paused = false }
    replaceContent(htmlContent) {
        if (htmlContent !== "") {
            $("#" + this.container).html(htmlContent);
            if (this.callback != null) this.callback();
        }
    }
    refresh(forced = false) {
        if (!this.paused) {
            $.ajax({
                url: this.serviceURL + (forced ? (this.serviceURL.indexOf("?") > -1 ? "&" : "?") + "forceRefresh=true" : ""),
                dataType: "html",
                success: (htmlContent) => { this.replaceContent(htmlContent) }
            })
        }
    }
    command(url) {
        $.ajax({
            url: url,
            method: 'GET',
            success: () => { this.refresh(true) }
        });
    }
    confirmedCommand(message, url) {
        bootbox.confirm(message, (result) => { this.command(url) });
    }
}