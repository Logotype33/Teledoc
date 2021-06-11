let vue = new Vue({
    el: '#app',
    data: {
        founders: [

        ],
        founder: {
            INN: null,
            Name: null,
            Surname: null,
            Patronymic: null
        },
        selected: 'Entity',
        validated: true,

    },
    methods: {
        AddFounderToList(founder) {
            if (this.IsNull(founder.INN) && this.IsNull(founder.Name) && this.IsNull(founder.Surname) && this.IsNull(founder.Patronymic)) {
                if (this.selected === 'SP' && this.founders.length < 1) {

                    this.founders.push(founder)
                    this.founder = {}
                }
                else if (this.selected === 'Entity') {
                    this.founders.push(founder)
                    this.founder = {}
                }
            }
            else {

                this.validated = false

            }

        },
        deleteFounder(founder) {
            this.founders.splice(this.founders.indexOf(founder), 1)

        },
        IsNull(value) {
            if (value != '' && value != null && value != NaN) {
                return true
            }

            else {
                return false
            }
        }
    },
})
