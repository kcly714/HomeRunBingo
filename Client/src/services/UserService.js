import axios from 'axios'

export default class UserService {

    static create(data, onSuccess, onError) {
        console.log('this is a create service ', data)
        axios.post(`/api/user/login`, data)
            .then(response => onSuccess(response))
            .catch(error => onError(error))
    }

}