 // Configuración de API
        

        let currentSection = 'usuarios';
        let dataTable;

        // Configuraciones de columnas por sección
        const tableConfigs = {
            usuarios: {
                title: 'Gestión de Usuarios',
                columns: [
                    { data: 'id', title: 'ID' },
                    { data: 'name', title: 'Nombre' },
                    { data: 'email', title: 'Email' },
                    { data: 'username', title: 'Usuario' },
                    { 
                        data: null,
                        title: 'Acciones',
                        render: (data, type, row) => `
                            <button class="btn-editar bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded mr-2" data-id="${row.id}">Editar</button>
                            <button class="btn-eliminar bg-red-500 hover:bg-red-600 text-white px-3 py-1 rounded" data-id="${row.id}">Eliminar</button>
                        `
                    }
                ]
            },
            productos: {
                title: 'Gestión de Productos',
                columns: [
                    { data: 'id', title: 'ID' },
                    { data: 'title', title: 'Producto' },
                    { data: 'price', title: 'Precio', render: (data) => `$${data}` },
                    { data: 'category', title: 'Categoría' },
                    { 
                        data: null,
                        title: 'Acciones',
                        render: (data, type, row) => `
                            <button class="btn-editar bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded mr-2" data-id="${row.id}">Editar</button>
                            <button class="btn-eliminar bg-red-500 hover:bg-red-600 text-white px-3 py-1 rounded" data-id="${row.id}">Eliminar</button>
                        `
                    }
                ]
            },
            categorias: {
                title: 'Gestión de Categorías',
                columns: [
                    { data: null, title: 'ID', render: (data, type, row, meta) => meta.row + 1 },
                    { data: null, title: 'Nombre', render: (data) => data },
                    { 
                        data: null,
                        title: 'Acciones',
                        render: (data, type, row, meta) => `
                            <button class="btn-editar bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded mr-2" data-id="${meta.row}">Editar</button>
                            <button class="btn-eliminar bg-red-500 hover:bg-red-600 text-white px-3 py-1 rounded" data-id="${meta.row}">Eliminar</button>
                        `
                    }
                ]
            },
            pedidos: {
                title: 'Gestión de Pedidos',
                columns: [
                    { data: 'id', title: 'ID' },
                    { data: 'title', title: 'Título' },
                    { data: 'userId', title: 'Usuario' },
                    { 
                        data: null,
                        title: 'Acciones',
                        render: (data, type, row) => `
                            <button class="btn-editar bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded mr-2" data-id="${row.id}">Editar</button>
                            <button class="btn-eliminar bg-red-500 hover:bg-red-600 text-white px-3 py-1 rounded" data-id="${row.id}">Eliminar</button>
                        `
                    }
                ]
            }
        };

        // Inicializar DataTable
        function initDataTable(section) {
            if (dataTable) {
                dataTable.destroy();
            }

            const config = tableConfigs[section];
            $('#section-title').text(config.title);

            dataTable = $('#dataTable').DataTable({
                ajax: {
                    url: API_CONFIG[section],
                    dataSrc: ''
                },
                columns: config.columns,
                language: {
                    url: '//cdn.datatables.net/plug-ins/1.10.21/i18n/Spanish.json'
                },
                responsive: true
            });
        }

        // Cambiar sección
        $('.menu-item').click(function(e) {
            e.preventDefault();
            $('.menu-item').removeClass('bg-gray-700');
            $(this).addClass('bg-gray-700');
            currentSection = $(this).data('section');
            initDataTable(currentSection);
        });

        // Modal
        $('#btn-nuevo').click(() => {
            $('#modal-title').text('Nuevo Registro');
            $('#formulario')[0].reset();
            $('#record-id').val('');
            $('#modal').addClass('active');
        });

        $('#btn-cerrar, #btn-cancelar').click(() => {
            $('#modal').removeClass('active');
        });

        // Editar
        $(document).on('click', '.btn-editar', function() {
            const id = $(this).data('id');
            $('#modal-title').text('Editar Registro');
            $('#record-id').val(id);
            
            $.get(`${API_CONFIG[currentSection]}/${id}`, function(data) {
                $('#nombre').val(data.name || data.title || data);
                $('#email').val(data.email || '');
            });
            
            $('#modal').addClass('active');
        });

        // Eliminar
        $(document).on('click', '.btn-eliminar', function() {
            if (confirm('¿Está seguro de eliminar este registro?')) {
                const id = $(this).data('id');
                $.ajax({
                    url: `${API_CONFIG[currentSection]}/${id}`,
                    method: 'DELETE',
                    success: function() {
                        alert('Registro eliminado exitosamente');
                        dataTable.ajax.reload();
                    }
                });
            }
        });

        // Guardar
        $('#formulario').submit(function(e) {
            e.preventDefault();
            const id = $('#record-id').val();
            const method = id ? 'PUT' : 'POST';
            const url = id ? `${API_CONFIG[currentSection]}/${id}` : API_CONFIG[currentSection];
            
            const data = {
                name: $('#nombre').val(),
                email: $('#email').val(),
                status: $('#estado').val()
            };

            $.ajax({
                url: url,
                method: method,
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function() {
                    alert('Registro guardado exitosamente');
                    $('#modal').removeClass('active');
                    dataTable.ajax.reload();
                }
            });
        });

        // Inicializar
        $(document).ready(function() {
            initDataTable(currentSection);
        });