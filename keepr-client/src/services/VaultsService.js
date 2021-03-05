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

  async getActiveVault(id) {
    const res = await api.get('api/vaults/' + id)
    console.log(res)
    AppState.activeVault = res.data
  }

  async createVault(newVault) {
    await api.post('api/vaults', newVault)
  }

  async deleteVault(id) {
    console.log(id)
    if (confirm('Confirm deletion?')) { await api.delete('api/vaults/' + id) }
    // this.getNotes(note.bug)
  }
}

export const vaultsService = new VaultsService()
