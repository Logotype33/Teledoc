let vue = new Vue({
    el: '#app',
    data: {
        founders: [
                
        ],
        founder: {
            INN: '',
            Name: '',
            Surname: '',
            Patronymic: ''
        },
        selected: 'Entity'
    },
    methods: {
        AddFounderToList(founder) {
            if (this.selected === 'SP' && this.founders.length < 1) {

                this.founders.push(founder)
                this.founder = {}
            }
            else if (this.selected === 'Entity') {
                this.founders.push(founder)
                this.founder = {}
            }
        },
        deleteFounder(founder) {
            this.founders.splice(this.founders.indexOf(founder), 1)

        },
    },
})
