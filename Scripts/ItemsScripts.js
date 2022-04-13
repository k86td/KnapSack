
/* TODO 
    Make this a little more generic to receive different input and generate an Ajax request 
*/
const updateFilters = (fieldsetId, dataContainerId, partialDataUrl) => {
    let selection = $(`${fieldsetId} input`);
    let queryParams = [];

    selection.map(el => {
        if (selection[el].checked)
            queryParams.push(`typeFilterInclude=${selection[el].value}`);
    });


    if (queryParams.length >= 0) {
        let finalUrl = partialDataUrl + "?" + queryParams.join("&");

        console.debug("Final Url is " + finalUrl);

        // code to execute when there's a filter update query
        $.ajax({
            type: "GET",
            url: finalUrl,

            success: (data) => {
                console.debug("Successfully pulled data from " + finalUrl);
                $(dataContainerId).html(data);
            },

            error: () => {
                console.error("There was an error while fetching " + finalUrl);
            }
        });
    }
}