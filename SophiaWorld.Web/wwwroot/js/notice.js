$(document).ready(function () {
    const tableBody = $('#noticeTable tbody');
    const editModal = new bootstrap.Modal(document.getElementById('editModal'));

    loadNotices();

    // ✅ 공지 불러오기
    function loadNotices() {
        $.ajax({
            url: '/api/notice',
            type: 'GET',
            success: function (data) {
                tableBody.empty();
                if (!data || data.length === 0) {
                    tableBody.append('<tr><td colspan="4" class="text-center text-muted py-3">등록된 공지가 없습니다.</td></tr>');
                    return;
                }

                data.forEach((notice, idx) => {
                    const date = new Date(notice.date).toLocaleDateString();
                    const row = `
                        <tr>
                            <td class="text-center">${idx + 1}</td>
                            <td>
                                <a href="#" class="text-decoration-none text-dark notice-title" data-id="${notice.id}" data-title="${notice.title}">
                                    ${notice.title}
                                </a>
                            </td>
                            <td class="text-center">${date}</td>
                            <td class="text-center">
                                <button class="btn btn-sm btn-outline-danger btn-delete" data-id="${notice.id}">삭제</button>
                            </td>
                        </tr>`;
                    tableBody.append(row);
                });
            },
            error: function () {
                alert('공지 목록을 불러올 수 없습니다.');
            }
        });
    }

    // ✅ 공지 등록
    $('#btnSaveNotice').on('click', function () {
        const title = $('#noticeTitle').val().trim();
        if (!title) {
            alert('제목을 입력하세요!');
            return;
        }

        $.ajax({
            url: '/api/notice',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ title: title }),
            success: function () {
                $('#noticeTitle').val('');
                $('#createModal').modal('hide');
                loadNotices();
            },
            error: function () {
                alert('공지 등록 중 오류가 발생했습니다.');
            }
        });
    });

    // ✅ 공지 수정 (제목 클릭 → 모달 열기)
    $(document).on('click', '.notice-title', function (e) {
        e.preventDefault();
        const id = $(this).data('id');
        const title = $(this).data('title');

        $('#editNoticeId').val(id);
        $('#editNoticeTitle').val(title);

        // ✅ Bootstrap 5 방식으로 오픈
        editModal.show();
    });

    // ✅ 수정 저장
    $('#btnUpdateNotice').on('click', function () {
        const id = $('#editNoticeId').val();
        const newTitle = $('#editNoticeTitle').val().trim();
        if (!newTitle) { alert('수정할 제목을 입력하세요.'); return; }

        $.ajax({
            url: `/api/notice/${id}`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify({ title: newTitle }),
            success: function () {
                editModal.hide();   // ✅ 닫기
                loadNotices();
            },
            error: function () {
                alert('공지 수정 중 오류가 발생했습니다.');
            }
        });
    });

    // ✅ 공지 삭제
    $(document).on('click', '.btn-delete', function () {
        const id = $(this).data('id');
        if (confirm('이 공지를 삭제하시겠습니까?')) {
            $.ajax({
                url: `/api/notice/${id}`,
                type: 'DELETE',
                success: function () {
                    loadNotices();
                },
                error: function () {
                    alert('삭제 실패!');
                }
            });
        }
    });
});
