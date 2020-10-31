function ParseAndSortTickets(ticketsInfo, sortingProperty)
{
    class Ticket
    {
        destination;
        price;
        status;

        constructor(destination, price, status)
        {
            this.destination = destination;
            this.price = +price;
            this.status = status;
        }

        static parse(text)
        {
            const [destination, priceText, status] = text.split('|');

            return new Ticket(destination, parseFloat(priceText), status);
        }
    }

    const tickets = [];
    for (const ticketInfo of ticketsInfo)
    {
        const ticket = Ticket.parse(ticketInfo);
        tickets.push(ticket);
    }

    tickets.sort((a, b) =>
    {
        if (a[sortingProperty].localeCompare)
        {
            return a[sortingProperty].localeCompare(b[sortingProperty]);
        }
        else
        {
            return a[sortingProperty] - b[sortingProperty];
        }
    });

    return tickets;
}