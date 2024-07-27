$(document).ready(function () {
    alert();
	context.init({preventDoubleContext: false});
	context.attach('body', [
        { header: 'Action' },
		{ divider: true },
		{ text: 'Copier', id: 'ContextCopier' },
		{ text: 'Coller', id: 'ContextColler' },
        { header: 'Scoring' },
		{ divider: true },
        { text: 'Enregistrer', id: 'ContextEnregistre', contextAction: 'ContextEnregistre()' },
		{ text: 'Annuler', id: 'ContextAnnuler', contextAction: 'ContextAnnuler()' }
	]);
});
