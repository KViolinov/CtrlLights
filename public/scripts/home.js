document.addEventListener('DOMContentLoaded', function () {
    const frequencyInput = document.getElementById('green-light-frequency');
    const frequencyValue = document.getElementById('frequency-value');
    const trafficTierSelect = document.getElementById('traffic-tier');
    const applySettingsButton = document.getElementById('apply-settings');
    const trafficStatusA = document.getElementById('traffic-status-a');
    const trafficStatusB = document.getElementById('traffic-status-b');

    frequencyInput.addEventListener('input', function () {
        frequencyValue.textContent = frequencyInput.value;
    });

    applySettingsButton.addEventListener('click', function () {
        const frequency = frequencyInput.value;
        const tier = trafficTierSelect.value;
        
        trafficStatusA.textContent = `Green (${frequency}s)`;
        trafficStatusA.classList.add('good');
        trafficStatusB.textContent = `Red (${tier} traffic)`;
        trafficStatusB.classList.add('bad');

        alert(`Settings applied: Frequency = ${frequency}s, Tier = ${tier}`);
    });
});

async function fetchTrafficLights() {
    const response = await fetch("/traffic-lights");
    const data = await response.json();
    
    data.forEach(light => {
        startCountdown(light.id, light.remaining_seconds, light.status);
    });
}

function startCountdown(id, seconds, status) {
    let timeLeft = seconds;

    const interval = setInterval(async () => {
        timeLeft--;

        if (timeLeft <= 0) {
            clearInterval(interval);
            const response = await fetch("/traffic-lights/switch", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ id })
            });

            const newLight = await response.json();
            startCountdown(newLight.id, newLight.remaining_seconds, newLight.status);
        }

        updateUI(id, timeLeft, status);
    }, 1000);
}