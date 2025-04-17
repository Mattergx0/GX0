// app.js

// Simuleren van de beveiligingcontrole
document.getElementById('checkSecurity').addEventListener('click', function() {
    const resultDiv = document.getElementById('securityResult');
    resultDiv.style.display = 'block';

    setTimeout(() => {
        const isSafe = Math.random() > 0.5;
        resultDiv.innerHTML = isSafe ? 
            "<span class='safe'>Apparaat is beveiligd. Geen bedreigingen gedetecteerd.</span>" : 
            "<span class='unsafe'>Waarschuwing: Onveilige apps gevonden!</span>";
        resultDiv.classList.add(isSafe ? 'safe' : 'unsafe');
    }, 1000);
});

// Simuleren van privacycontrole
document.getElementById('privacyBtn').addEventListener('click', function() {
    alert("Controleer je privacy-instellingen in de systeeminstellingen.");
});

// Simuleren van beveiligingsalerts
document.addEventListener('DOMContentLoaded', function() {
    const alertsList = document.getElementById('alertsList');
    const alerts = [
        "Mogelijke phishing-aanval gedetecteerd.",
        "Ongewone inlogpoging gedetecteerd.",
        "Onbeveiligd netwerk gedetecteerd."
    ];

    alerts.forEach(alert => {
        const alertItem = document.createElement('p');
        alertItem.textContent = alert;
        alertsList.appendChild(alertItem);
    });
});
