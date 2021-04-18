$(function () {
    var l = abp.localization.getResource('ELRD');

    var dataTable = $('#HospitalsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(iuKRG.eLRD.hospitals.hospital.getList),
            columnDefs: [
                {
                    title: l('BaseHospitals:Name'),
                    data: "Name"
                },
                {
                    title: l('BaseHospitals:City'),
                    data: "City"
                },
                {
                    title: l('BaseHospitals:Long'),
                    data: "Long"
                },
                {
                    title: l('BaseHospitals:Lat'),
                    data: "Lat"
                },
                {
                    title: l('BaseHospitals:CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );
});