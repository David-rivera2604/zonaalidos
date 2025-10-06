DELETE FROM CUSTOMDATA c WHERE key1 = 'PlanTramitacion';

INSERT INTO CUSTOMDATA (ID,COMPANYID,ENTITYTYPE,ENTITYSUBTYPE,ENTITYID,"DATA",KEY1,KEY2,UPDATEUSERCODE,UPDATEDATE) VALUES ((SELECT MAX(ID)+1 FROM CUSTOMDATA),0,2000,0,1,TO_CLOB('class PlanTramitacion {
  constructor(containerId, json) {
    this.el = document.getElementById(containerId);
    this.rows = (json && json.Plantramitacion) ? json.Plantramitacion.slice() : [];
    this.fmt = new Intl.DateTimeFormat(''es-CR'', { year: ''2-digit'', month: ''2-digit'', day: ''2-digit'', hour: ''2-digit'', minute: ''2-digit'' });
  }

  render() {
    if (!this.el) return;
    const items = this.#prepare(this.rows);

    // Agrupar por Nivel ? Trámite
    const byNivel = new Map();
    for (const it of items) {
      const kNivel = it.codNivel || it.nivel;
      if (!byNivel.has(kNivel)) byNivel.set(kNivel, { cod: it.codNivel, nombre: it.nomNivel, tramites: new Map() });
      const nivel = byNivel.get(kNivel);
      const kTram = it.codTramite + ''::'' + it.nomTramite;
      if (!nivel.tramites.has(kTram)) nivel.tramites.set(kTram, {
        cod: it.codTramite,
        nombre: it.nomTramite,
        tipo: it.tipoTramite || '''',
        items: []
      });
      nivel.tramites.get(kTram).items.push(it);
    }

    // Encabezado (Plan + #niveles)
    const header = document.getElementById(''headerTitle'');
    if (header) header.textContent = `${this.#planLabel(this.rows)} ? ${byNivel.size} niveles`;

    // Render (niveles abiertos, trámites abiertos por defecto)
    let html = '''';
    let nivCount = 0;
    for (const nivel of Array.from(byNivel.values()).sort((a, b) => String(a.cod).localeCompare(String(b.cod)))) {
      const nid = `nivel_${++nivCount}`;
      const tramites = Array.from(nivel.tramites.values()).sort((a, b) => String(a.cod).localeCompare(String(b.cod)));

      let tramHtml = '''';
      let tCount = 0;
      for (const tramite of tramites) {
        const tid = `${nid}_tram_${++tCount}`;
        tramHtml += this.#renderTramiteBlock(tramite, tid, true); // abierto por defecto
      }

      html += `
        <div class="nivel-block">
          <div class="nivel-header collapse-toggle" data-toggle="collaps')||TO_CLOB('e" data-target="#${nid}" aria-controls="${nid}" aria-expanded="true">
            <i class="fa fa-chevron-down mr-2 toggle-icon" aria-hidden="true"></i>
            <strong title="Nivel ${this.#esc(nivel.cod || '''')}">
              ${this.#esc(nivel.nombre || ''(Sin nombre)'')}
            </strong>
            <span class="badge badge-info ml-2 count-badge" title="Trámites">${tramites.length}</span>
          </div>
          <div id="${nid}" class="collapse show">${tramHtml}</div>
        </div>`;
    }

    this.el.innerHTML = html || ''<p class="text-muted mb-0">Sin actividades registradas.</p>'';

    // Conectar iconos/badges a eventos de colapso (con jQuery si existe, si no, fallback a MutationObserver)
    this.#wireToggles();
  }

  #renderTramiteBlock(tramite, id, open) {
    const n = tramite.items.length;
    return `
      <div class="tramite-block">
        <div class="tramite-header collapse-toggle" data-toggle="collapse" data-target="#${id}" aria-controls="${id}" aria-expanded="${open ? ''true'' : ''false''}">
          <i class="fa ${open ? ''fa-chevron-down'' : ''fa-chevron-right''} mr-2 toggle-icon" aria-hidden="true"></i>
          <strong title="${this.#esc(tramite.tipo || ''Tramite '')} ${this.#esc(tramite.cod || '''')}">
            ${this.#esc(tramite.nombre || ''(Trámite)'')}
          </strong>
          <span class="badge badge-secondary ml-2 count-badge" title="Observaciones">${n}</span>
        </div>
        <div id="${id}" class="collapse${open ? '' show'' : ''''}">
          <div class="activity-stream">
            ${tramite.items.map(it => this.#renderItem(it)).join('''')}
          </div>
        </div>
      </div>`;
  }

  #renderItem(it) {
    const when = it.fecha ? this.fmt.format(it.fecha) : '''';
    return `
      <div class="stream">
        <div class="stream-badge"><i class="fa ${it.icon} ${it.color}"></i></div>
        <div class="stream-panel">
          <div class="obs-text">${this.#esc(it.texto)}</div')||TO_CLOB('>
          <div class="meta-line">
            <span class="who">${this.#esc(it.usuario)}</span>
            <span class="date">${this.#esc(when)}</span>
          </div>
        </div>
      </div>`;
  }

  // ===== toggles: icono y badge =====
  #wireToggles() {
    const toggles = this.el.querySelectorAll(''.collapse-toggle'');
    toggles.forEach(tog => {
      const targetSel = tog.getAttribute(''data-target'');
      const target = document.querySelector(targetSel);
      const icon = tog.querySelector(''.toggle-icon'');
      const badge = tog.querySelector(''.count-badge'');

      const applyState = () => {
        const expanded = target.classList.contains(''show'');
        if (icon) {
          icon.classList.toggle(''fa-chevron-down'', expanded);
          icon.classList.toggle(''fa-chevron-right'', !expanded);
        }
        if (badge) {
          badge.style.display = expanded ? ''none'' : ''inline-block'';
        }
        tog.setAttribute(''aria-expanded'', expanded ? ''true'' : ''false'');
      };

      // Estado inicial
      applyState();

      // Con Bootstrap + jQuery
      if (window.jQuery && typeof jQuery(target).on === ''function'') {
        jQuery(target).on(''shown.bs.collapse'', applyState);
        jQuery(target).on(''hidden.bs.collapse'', applyState);
      } else {
        // Fallback sin jQuery: observar cambios de clase
        const mo = new MutationObserver(applyState);
        mo.observe(target, { attributes: true, attributeFilter: [''class''] });
      }
    });
  }

  // --- helpers ---
  #prepare(rows) {
    const out = []; const seen = new Set();
    for (const r of rows) {
      const key = JSON.stringify([r.COD_NIVEL, r.COD_TRAMITE, r.NUM_SECU, r.OBS_TRAMITE, r.COD_USR, r.FEC_ACTU]);
      if (seen.has(key)) continue; seen.add(key);
      const fechaISO = r.FEC_ACTU || r.FEC_INICIO || null;
      out.push({
        codNivel: r.COD_NIVEL,
        nomNivel: r.NOM_NIVEL,
        codTramite: r.CO')||TO_CLOB('D_TRAMITE,
        nomTramite: r.NOM_TRAMITE,
        tipoTramite: r.NOM_TIP_TRAMITE || r.TIP_TRAMITE || '''',
        usuario: r.COD_USR || '''',
        texto: r.OBS_TRAMITE || '''',
        fecha: fechaISO ? new Date(fechaISO) : null,
        icon: this.#pickIcon(r),
        color: this.#pickColor(r)
      });
    }
    out.sort((a, b) => (b.fecha?.getTime() || 0) - (a.fecha?.getTime() || 0));
    return out;
  }
  #planLabel(rows) {
    if (!rows || !rows.length) return ''Plan de tramitación'';
    const r0 = rows[0];
    if (r0.NOM_PLAN) return r0.NOM_PLAN;
    if (r0.COD_PLAN) return `Plan ${r0.COD_PLAN}`;
    return ''Plan de tramitación'';
  }
  #pickIcon(r) {
    const t = (r.OBS_TRAMITE || '''').toLowerCase();
    if (t.includes(''aviso'')) return ''fa-envelope'';
    if (t.includes(''banco'')) return ''fa-bank'';
    if (t.includes(''agenda'')) return ''fa-calendar'';
    return ''fa-check'';
  }
  #pickColor(r) {
    const e = (r.NOM_TIP_EST_TRAMITE || '''').toLowerCase();
    if (e.includes(''pend'')) return ''bg-warning'';
    if (e.includes(''iniciado'') || e.includes(''activo'')) return ''bg-success'';
    if (e.includes(''final'') || e.includes(''complet'') || e.includes(''cerr'')) return ''bg-primary'';
    return '''';
  }
  #tramLabel(n) { return n === 1 ? ''trámite'' : ''trámites'' }
  #obsLabel(n) { return n === 1 ? ''observación'' : ''observaciones'' }
  #esc(s) { return String(s || '''').replace(/&/g, ''&amp;'').replace(/</g, ''&lt;'').replace(/>/g, ''&gt;'').replace(/\"/g, ''&quot;'').replace(/''/g, ''&#39;''); }
}

app.ui.ShowSideBar({ title: ''Plan de tramitación'', subtitle: `Siniestro #${context}`, isHTML: true, HTML: `<div id="plan-container"></div>`, data: null, width: ''40%'' });

$(''.sidebar-content'').toggleClass(''sk-loading'');
app.core.datapi(''GET'', `siniestro/${context}?include=plantramitacion`)
  .then(data => {
    if (data !== null) {
      $(''.sidebar-content'').toggleClass(''sk-loading'');
      new PlanTramitacion(''plan-container'', data).render();
    }
')||TO_CLOB('
  });
'),'PlanTramitacion','Render',6329,TIMESTAMP'2025-07-23 19:15:09');
