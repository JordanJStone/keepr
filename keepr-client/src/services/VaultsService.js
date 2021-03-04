import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getMyVaults(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    console.log(res.data)
    AppState.myVaults = res.data
  }

  // getAllKeeps(route.params.id)
  async getAllKeeps(id) {
    const res = await api.get('api/vaults/' + id + '/keeps')
    console.log(res)
    AppState.singleVaultKeeps = res.data
  }

  // async getOne(id) {
  //   const res = await api.get('api/vaults/' + id)
  //   AppState.activeKeep = res.data
  //   console.log(AppState.activeVault)
  // }
}

export const vaultsService = new VaultsService()
