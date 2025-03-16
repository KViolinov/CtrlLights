document.addEventListener('DOMContentLoaded', function () {
    const trafficLights = Array.from({ length: 8 }, (_, i) => ({
        id: i + 1,
        status: i % 2 === 0 ? "Green" : "Red",
        waveDirection: i % 2 === 0 ? "North" : "South",
        waveDelay: 10,
        greenFrequency: 30,
        redFrequency: 30,
    }));

    let currentTrafficLight = 1;

    function updateTrafficLightDisplay() {
        const currentLight = trafficLights[currentTrafficLight - 1];
    
        document.getElementById("current-light").textContent = currentTrafficLight;
        document.getElementById("traffic-status").textContent = currentLight.status;
        document.getElementById("wave-direction").textContent = currentLight.waveDirection;
        document.getElementById("wave-delay").textContent = currentLight.waveDelay;

        document.getElementById("green-light-frequency").value = currentLight.greenFrequency;
        document.getElementById("green-frequency-input").value = currentLight.greenFrequency;
        document.getElementById("red-light-frequency").value = currentLight.redFrequency;
        document.getElementById("red-frequency-input").value = currentLight.redFrequency;
    }

    // Navigation Arrows
    document.getElementById("prev-light").addEventListener("click", () => {
        currentTrafficLight = currentTrafficLight > 1 ? currentTrafficLight - 1 : 8;
        updateTrafficLightDisplay();
    });

    document.getElementById("next-light").addEventListener("click", () => {
        currentTrafficLight = currentTrafficLight < 8 ? currentTrafficLight + 1 : 1;
        updateTrafficLightDisplay();
    });

    // Apply Traffic Light Controls
    document.getElementById("apply-traffic-controls").addEventListener("click", () => {
        const currentLight = trafficLights[currentTrafficLight - 1];
        currentLight.greenFrequency = parseInt(document.getElementById("green-light-frequency").value);
        currentLight.redFrequency = parseInt(document.getElementById("red-light-frequency").value);
        alert(`Settings applied for Intersection ${currentTrafficLight}`);
    });

    document.getElementById("apply-green-wave").addEventListener("click", () => {
        const waveDelay = parseInt(document.getElementById("green-wave-delay").value);
        alert(`Green Wave Delay applied: ${waveDelay} seconds`);
    });

    const greenWaveDelayInput = document.getElementById("green-wave-delay");
    const waveDelayInput = document.getElementById("wave-delay-input");

    greenWaveDelayInput.addEventListener("input", () => {
        waveDelayInput.value = greenWaveDelayInput.value;
    });

    waveDelayInput.addEventListener("input", () => {
        greenWaveDelayInput.value = waveDelayInput.value;
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