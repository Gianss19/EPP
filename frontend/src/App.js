document.addEventListener('DOMContentLoaded', function () {
    const app = document.getElementById('app');

    // Crea el input y botón para buscar por id
    const inputContainer = document.createElement('div');
    inputContainer.innerHTML = `
        <input type="number" id="conceptoId" placeholder="Ingresa ID del concepto" />
        <button id="buscarBtn">Buscar</button>
    `;
    app.appendChild(inputContainer);

    const resultadoContainer = document.createElement('div');
    resultadoContainer.id = 'resultado';
    app.appendChild(resultadoContainer);

    // Función para renderizar el concepto
    function renderConcepto(concepto) {
        if (!concepto) {
            resultadoContainer.innerHTML = '<p>Concepto no encontrado.</p>';
            return;
        }

        resultadoContainer.innerHTML = `
            <h1>Concepto de EPP</h1>
            <p><strong>ID:</strong> ${concepto.idEpp}</p>
            <p><strong>Nombre:</strong> ${concepto.concepto}</p>
            <p><strong>Unidad de medida:</strong> ${concepto.unidadMedida}</p>
            <p><strong>Es resguardo:</strong> ${concepto.esResguardo}</p>
            <p><strong>Stock:</strong> ${concepto.stock !== null ? concepto.stock : 'N/A'}</p>
        `;
    }

    // Función para hacer fetch
    function buscarConcepto(id) {
        fetch(`http://localhost:5000/conceptosEpp/${id}`)
            .then(response => {
                if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
                return response.json();
            })
            .then(data => renderConcepto(data))
            .catch(error => {
                console.error('Error fetching concepto:', error);
                resultadoContainer.innerHTML = '<p>Error cargando el concepto.</p>';
            });
    }

    // Evento click del botón
    document.getElementById('buscarBtn').addEventListener('click', () => {
        const id = document.getElementById('conceptoId').value;
        if (id) {
            buscarConcepto(id);
        } else {
            resultadoContainer.innerHTML = '<p>Por favor ingresa un ID válido.</p>';
        }
    });
});
