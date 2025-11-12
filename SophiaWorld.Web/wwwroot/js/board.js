$(document).ready(function () {
    const tableBody = $('#boardTable tbody');
    const editModal = new bootstrap.Modal(document.getElementById('editModal'));
    const createModal = new bootstrap.Modal(document.getElementById('createModal'));

    loadPosts();

    function loadPosts() {
        $.ajax({
            url: '/api/board',
            type: 'GET',
            success: function (data) {
                tableBody.empty();
                if (!data || data.length === 0) {
                    tableBody.append('<tr><td colspan="4" class="text-center text-muted py-3">등록된 글이 없습니다.</td></tr>');
                    return;
                }

                data.forEach((post, idx) => {
                    const date = new Date(post.createdAt).toLocaleDateString();
                    const row = `
                        <tr>
                            <td class="text-center">${idx + 1}</td>
                            <td><a href="#" class="text-dark board-title" data-id="${post.id}" data-title="${post.title}" data-content="${post.content}">${post.title}</a></td>
                            <td class="text-center">${date}</td>
                            <td class="text-center"><button class="btn btn-sm btn-outline-danger btn-delete" data-id="${post.id}">삭제</button></td>
                        </tr>`;
                    tableBody.append(row);
                });
            },
            error: function () {
                alert('게시글을 불러오지 못했습니다.');
            }
        });
    }

    $('#btnSaveBoard').on('click', function () {
        const title = $('#boardTitle').val().trim();
        const content = $('#boardContent').val().trim();
        if (!title || !content) {
            alert('제목과 내용을 모두 입력하세요.');
            return;
        }

        $.ajax({
            url: '/api/board',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ title, content }),
            success: function () {
                $('#boardTitle').val('');
                $('#boardContent').val('');
                createModal.hide();
                loadPosts();
            },
            error: function () {
                alert('글 등록 중 오류가 발생했습니다.');
            }
        });
    });

    $(document).on('click', '.board-title', function (e) {
        e.preventDefault();
        const id = $(this).data('id');
        const title = $(this).data('title');
        const content = $(this).data('content');
        $('#editBoardId').val(id);
        $('#editBoardTitle').val(title);
        $('#editBoardContent').val(content);
        editModal.show();
    });

    $('#btnUpdateBoard').on('click', function () {
        const id = $('#editBoardId').val();
        const title = $('#editBoardTitle').val().trim();
        const content = $('#editBoardContent').val().trim();
        if (!title || !content) {
            alert('제목과 내용을 입력하세요.');
            return;
        }

        $.ajax({
            url: `/api/board/${id}`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify({ title, content }),
            success: function () {
                editModal.hide();
                loadPosts();
            },
            error: function () {
                alert('글 수정 중 오류가 발생했습니다.');
            }
        });
    });

    $(document).on('click', '.btn-delete', function () {
        const id = $(this).data('id');
        if (confirm('이 글을 삭제하시겠습니까?')) {
            $.ajax({
                url: `/api/board/${id}`,
                type: 'DELETE',
                success: function () {
                    loadPosts();
                },
                error: function () {
                    alert('삭제 실패!');
                }
            });
        }
    });
});
