<template>
  <a class="dropdown-item" href="#" @click.prevent="createVaultKeep(keepProp, vaultProps.id)">{{ vaultProps.name }}</a>
</template>

<script>
import { vaultKeepsService } from '../services/VaultKeepsService'
import { logger } from '../utils/Logger'
export default {
  name: 'DropdownComponent',
  props: {
    vaultProps: { type: Object, required: true },
    keepProp: { type: Object, required: true }
  },
  setup() {
    return {
      createVaultKeep(keep, newVaultId) {
        try {
          // console.log('keepprop, vaultprop id', oldVaultId, newVaultId)
          vaultKeepsService.createVaultKeep(keep, newVaultId)
        } catch (error) {
          logger.log(error)
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
