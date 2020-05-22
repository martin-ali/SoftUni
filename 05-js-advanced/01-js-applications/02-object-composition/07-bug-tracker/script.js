function solve()
{
    function getHtmlFromReport(report)
    {
        return ` <div id="report_${report.id}" class="report">
<div class="body">
<p>${report.description}</p>
</div>
<div class="title">
<span class="author">Submitted by: ${report.author}</span>
<span class="status">${report.status} | ${report.severity}</span>
</div>
</div>`;

    }

    function refreshReports(reports)
    {
        const contentParent = document.querySelector(contentDisplaySelector);
        contentParent.innerHTML = '';

        for (const report of reports)
        {
            const reportHtml = getHtmlFromReport(report);

            contentParent.innerHTML += reportHtml;
        }
    }

    let id = 0;
    const reports = [];
    let contentDisplaySelector = '#content;';

    const bugTracker = {
        /**
         * @param {string} author
         * @param {string} description
         * @param {boolean} reproducible
         * @param {string} severity
         */
        report(author, description, reproducible, severity)
        {
            const report = {
                id: id++,
                author,
                description,
                reproducible,
                severity,
                status: 'Open'
            };

            reports.push(report);

            refreshReports(reports);
        },

        /**
         * @param {number} id
         * @param {string} newStatus
         */
        setStatus(id, newStatus)
        {
            const report = reports.find(r => r.id === id);

            report.status = newStatus;

            refreshReports(reports);
        },

        /**
         * @param {number} id
         */
        remove(id)
        {
            const reportId = reports.findIndex(r => r.id === id);

            reports.splice(reportId, 1);

            refreshReports(reports);
        },

        sort(method)
        {
            const sortedReports = Array.from(reports);
            sortedReports.sort((a, b) => String(a[method]).localeCompare(String(b[method])));

            refreshReports(sortedReports);
        },

        output(selector)
        {
            contentDisplaySelector = selector;
        }
    };

    return bugTracker;
}