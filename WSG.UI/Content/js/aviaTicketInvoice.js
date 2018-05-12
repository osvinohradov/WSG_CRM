function ajaxInvoiceTest () {

    // Invoice Popup Event Listener
    var invoice_modal = document.getElementById("createNewInvoice");
    invoice_modal.addEventListener('click', createInvoicePopup);

    // Invoice Popup AJAX
    function createInvoicePopup() {

        var doc = document.getElementById("myInvoiceModal");

        var xhr = new XMLHttpRequest();
        xhr.open("GET", "/AviaTickets/Invoice/Create");

        xhr.onload = function () {
            if (xhr.status == 200) {
                console.log(xhr.response);
                //doc.innerHTML = xhr.response;
            }
        }
        xhr.send();
    }

    //Invoice Popup New Ticket Event Listener
    //var new_ticket = document.getElementById("saveAviaTicket"); // id from: InvoicePopUp (line 47) "Записати" button
    //new_ticket.addEventListener('click', createAviaTicket);

    //// Invoice Popup New Ticket AJAX
    //function createAviaTicket() {

    //    var xhr = new XMLHttpRequest();
    //    xhr.open("POST", "/AviaTickets/Invoice/Create");
    //    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    //    xhr.onload = function () {
    //        if (xhr.status == 200) {
    //            console.log(xhr.response);
    //        }
    //    }
    //    xhr.send();
    //}


    // Invoice New Ticket Event Listener
    //var new_ticket = document.getElementById("invoiceSave"); // id from: Invoice (line 43) "Записати" button
    //new_ticket.addEventListener('click', createAviaTicket_Test);

    //// Invoice Popup New Ticket AJAX
    //function createAviaTicket_Test() {

    //    var xhr = new XMLHttpRequest();
    //    xhr.open("POST", "/AviaTickets/Invoice/Create");
    //    xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

    //    xhr.onload = function () {
    //        if (xhr.status == 200) {
    //            console.log(xhr.response);
    //        }
    //    }

    //    xhr.send();
    //}


    // Invoice Edit Event Listener
    var invoice_edit = document.getElementById("invoiceEdit"); // id from: Invoice (line 31) "Змінити" button 
    invoice_edit.addEventListener('click', editInvoice);

    // Invoice Edit AJAX
    function editInvoice() {

        var xhr = new XMLHttpRequest();
        xhr.open("GET", "/AviaTickets/Invoice/Edit");

        xhr.onload = function () {
            if (xhr.status == 200) {
                console.log(xhr.response);
            }
        }
        xhr.send();
    }

    // Invoice Update Event Listener
    var invoice_update = document.getElementById("invoiceUpdate"); // id from: Invoice (line 37) "Оновити" button
    invoice_update.addEventListener('click', updateInvoice);

    // Invoice Update AJAX
    function updateInvoice() {

        var xhr = new XMLHttpRequest();
        xhr.open("PUT", "/AviaTickets/Invoice/Update");

        xhr.onload = function () {
            if (xhr.status == 200) {
                console.log(xhr.response);
            }
        }
        xhr.send();
    }

}

