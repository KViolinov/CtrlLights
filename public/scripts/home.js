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