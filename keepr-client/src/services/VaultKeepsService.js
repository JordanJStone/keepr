// import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultKeepsService {
  // async getRelationshipId(vaultId) {
  //   await api.get('api/vaults/' + vaultId + '/keeps')
  // }

  async removeKeepFromVault(keepProp) {
    console.log(keepProp)
    if (confirm('Confirm deletion?')) { await api.delete('api/vaultkeeps/' + keepProp.vaultKeepId) }
  }

  async createVaultKeep(keep, newVaultId) {
    console.log(keep, newVaultId)
    await api.post('api/vaultkeeps', { keepId: keep.id, vaultId: newVaultId })
  }

  // async createVaultKeep(ids) {
  //   console.log(ids)
  //   await api.post('api/vaultkeeps', ids)
  // }
}

export const vaultKeepsService = new VaultKeepsService()
