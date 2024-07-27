$(document).ready(function(){
	context.init({preventDoubleContext: false});
	context.attach('body', [
        {header: 'Action' },
		{divider: true},
		{ text: 'Copier', id: 'ContextCopier' },
		{ text: 'Coller', id: 'ContextColler' },
		{ text: 'Supprimer', id: 'ContextSupprimer' },
        { header: 'Scoring' },
		{ divider: true },
        { text: 'Enregistrer', id: 'ContextEnregistre' },
		{ text: 'Annuler', id: 'ContextAnnuler' },
		{ text: 'test', id: 'txtxx', contextAction: 'election()' }
	]);
});
