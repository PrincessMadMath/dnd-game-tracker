var messages = document.getElementsByClassName('sheet-rolltemplate-atkdmg');


Array.from(messages).forEach(element => {
    const result = parseElement(element);
    if (result) {
        console.log(result);
    }
});

function parseElement(element) {
    try {
        const isSpellWithDC = element.querySelector(".sheet-savedc");
        if (isSpellWithDC) {
            return parseSpellWithDCResult(element);
        }

        const isAttackAdv = element.querySelector(".sheet-adv");
        if (isAttackAdv) {
            return parseAdvAttackResult(element);
        }


        const isSpell = element.querySelector(".sheet-info");
        if (isSpell) {
            return parseSpellResult(element);
        }

        return parseAttackResult(element)

    } catch (error) {
        // console.log(element);
    }

}

function parseAttackResult(element) {

    const by = element.querySelector('.sheet-charname').innerText;
    const rollResultElement = element.querySelector('.inlinerollresult');
    const rollResult = rollResultElement.innerText;

    const rollDetails = rollResultElement.title;
    let diceRollRegex = new RegExp('\>(.*)\<');
    const diceRoll = rollDetails.match(diceRollRegex)[1];
    let modifierRegex = /\)(.*)/;
    const modifier = parseInt(rollDetails.match(modifierRegex)[1]);

    const rollName = element.querySelector('.sheet-label').firstElementChild.firstElementChild.previousSibling.textContent;

    const damageResult = element.querySelector('.sheet-damage').innerText.trim();
    const damageLabel = element.querySelector('.sheet-sublabel').innerText;

    const parsedResult = {
        by,
        rollName,
        rollResult,
        diceRoll,
        modifier,
        damageResult,
        damageLabel
    }

    return parsedResult;
}

function parseAdvAttackResult(element) {

    const by = element.querySelector('.sheet-charname').innerText;
    const rollResultElement = element.querySelector('.inlinerollresult');
    const rollResult = rollResultElement.innerText;

    const rollDetails = rollResultElement.title;
    let diceRollRegex = new RegExp('\>(.*)\<');
    const diceRoll = rollDetails.match(diceRollRegex)[1];
    let modifierRegex = /\)(.*)/;
    const modifier = parseInt(rollDetails.match(modifierRegex)[1]);

    const rollName = element.querySelector('.sheet-label').firstElementChild.firstElementChild.previousSibling.textContent;

    const damageElement = element.getElementsByClassName('sheet-adv')

    const damageResult = damageElement[0].querySelector('.sheet-damage').innerText.trim();
    const damageLabel = damageElement[0].querySelector('.sheet-sublabel').innerText;

    const secondaryDamageResult = damageElement[1].querySelector('.sheet-sublabel').previousElementSibling.innerText;

    const damageRegex = /^(\d*)/g;
    const advRegex = /(\d*)$/g;

    let damage = parseInt(damageResult.match(damageRegex)[0])
    damage += parseInt(damageResult.match(advRegex)[0]) ? parseInt(damageResult.match(advRegex)[0]) : 0
    damage += parseInt(secondaryDamageResult.match(damageRegex)[0]);
    damage += parseInt(secondaryDamageResult.match(advRegex)[0]) ? parseInt(secondaryDamageResult.match(advRegex)[0]) : 0

    const parsedResult = {
        by,
        rollName,
        rollResult,
        diceRoll,
        modifier,
        damageResult: damage,
        damageLabel
    }

    return parsedResult;
}

function parseSpellResult(element) {

    const by = element.querySelector('.sheet-charname').innerText;
    const rollResultElement = element.querySelector('.inlinerollresult');
    const rollResult = rollResultElement.innerText;

    const rollDetails = rollResultElement.title;
    let diceRollRegex = new RegExp('\>(.*)\<');
    const diceRoll = rollDetails.match(diceRollRegex)[1];
    let modifierRegex = /\)(.*)/;
    const modifier = parseInt(rollDetails.match(modifierRegex)[1]);

    const rollName = element.querySelector('.sheet-label').firstElementChild.firstElementChild.previousSibling.textContent;

    const damageResult = element.querySelector('.sheet-damage').innerText.trim();

    const damageElement = element.querySelector('.sheet-damage').nextElementSibling;
    const damageLabel = damageElement.innerText;

    const parsedResult = {
        by,
        rollName,
        rollResult,
        diceRoll,
        modifier,
        damageResult,
        damageLabel
    }

    return parsedResult;
}

function parseSpellWithDCResult(element) {

    const by = element.querySelector('.sheet-charname').innerText;

    const damageElementTemplate = element.querySelector('.sheet-damagetemplate')
    const rollName = damageElementTemplate.querySelector('.sheet-label').firstElementChild.textContent;

    const damageResult = element.querySelector('.sheet-damage').innerText.trim();

    const damageElement = element.querySelector('.sheet-damage').nextElementSibling;
    const damageLabel = damageElement.innerText;

    const parsedResult = {
        by,
        rollName,
        damageResult,
        damageLabel
    }

    return parsedResult;
}

