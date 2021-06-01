$(function () {
    var l = abp.localization.getResource('ELRD');
    var createModal = new abp.ModalManager(abp.appPath + 'Missions/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Missions/EditModal');

    var dataTable = $('#MissionsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(iuKRG.eLRD.missions.mission.getList),
            columnDefs: [
                {
                    title: l('Missions:Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('ELRD.Mission.CreateUpdate'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('ELRD.Mission.Delete'),
                                    confirmMessage: function (data) {
                                        return l('MissionDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        iuKRG.eLRD.missions.mission
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.success(l('SuccessfullyDeleted', data.record.name));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Mission:EndDate'),
                    data: "endDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('Mission:StartDate'),
                    data: "startDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('Mission:Location'),
                    data: "location"
                },
                {
                    title: l('Mission:Reason'),
                    data: "reason"
                },
                {
                    title: l('Mission:Number'),
                    data: "missionTaskNumber"
                },
                {
                    title: l('Mission:Commander'),
                    data: "userGuid",
                    render: lookUpUserName
                    //,
                    //render: function (data) {
                    //    volo.abp.identity.identityUser.get(data).done(function (result) {
                    //        return result.name
                    //    });
                    //}
                },
                {
                    title: l('Mission:CreationTime'), data: "creationTime",
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

    //This needs to go to the server side... with hunderts of missions, this might be a performance problem
    function lookUpUserName(data, type, row, meta) {
        let name = null;
        abp.ajax({
            type: 'GET',
            async: false,
            url: '/api/identity/users/' + data, //here is GUID data
        }).done(function (result) {
            name = result.name
        });
        return name   
    }

    createModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.success(l('SuccessfullyCreated'));
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.success(l('SuccessfullyEdited'));
    });

    $('#NewMissionButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});